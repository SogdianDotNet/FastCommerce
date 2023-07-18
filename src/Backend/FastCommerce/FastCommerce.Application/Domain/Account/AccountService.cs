using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Account.Dtos;
using FastCommerce.Application.Domain.Account.Interfaces;
using FastCommerce.Application.Domain.Account.Specifications;
using FastCommerce.Application.Domain.Vendors.Specifications;
using FastCommerce.Application.Exceptions;
using FastCommerce.Application.Helpers;
using FastCommerce.Application.Interfaces;
using FastCommerce.Application.Security;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Account.Enums;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Entities.Vendors;
using FastCommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Application.Domain.Account;

public sealed class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationAccount> _userManager;
    private readonly IRepository<ApplicationAccount> _applicationAccountRepository;
    private readonly IRepository<VendorAccount> _vendorAccountRepository;
    private readonly IClock _clock;
    private readonly IEncryptionService _encryptionService;

    public AccountService(
        IMapper mapper,
        UserManager<ApplicationAccount> userManager,
        IClock clock,
        IEncryptionService encryptionService,
        IRepository<VendorAccount> vendorAccountRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _clock = clock ?? throw new ArgumentNullException(nameof(clock));
        _encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
        _vendorAccountRepository = vendorAccountRepository ?? throw new ArgumentNullException(nameof(vendorAccountRepository));
    }

    public async Task<LoginResults> Login(string userNameOrEmail, string password, string? ipAddress, CancellationToken cancellationToken = default)
    {
        var isEmail = IsValidEmail(userNameOrEmail);

        var applicationAccount = await _applicationAccountRepository
            .FindSingleAsync(new ApplicationAccountByLoginSpec(userNameOrEmail, isEmail), cancellationToken);

        if (applicationAccount is null)
        {
            return LoginResults.UserNotExist;
        }

        if (applicationAccount.IsDeleted)
        {
            return LoginResults.Deleted;
        }

        if (!PasswordsMatch(applicationAccount!.PasswordHash!, password))
        {
            return LoginResults.WrongPassword;
        }

        if (applicationAccount.LockoutEnd.HasValue && applicationAccount.LockoutEnd > _clock.UtcNow && applicationAccount.LockoutEnabled == true)
        {
            return LoginResults.LockedOut;
        }

        applicationAccount.AccessFailedCount = 0;
        applicationAccount.LastLoginDateUtc = _clock.UtcNow;
        applicationAccount.ActivityLogs!.Add(new ActivityLog
        {
            Account = applicationAccount,
            IpAddress = ipAddress
        });

        await _applicationAccountRepository.UpdateAsync(applicationAccount, cancellationToken: cancellationToken);

        return LoginResults.Successful;
    }

    private bool PasswordsMatch(string hashedPassword, string enteredPassword)
    {
        if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(enteredPassword))
            return false;

        var saltKey = _encryptionService.CreateSaltKey(AccountServicesDefaults.PasswordSaltKeySize);
        return hashedPassword == _encryptionService.CreatePasswordHash(enteredPassword, saltKey, AccountServicesDefaults.DefaultHashedPasswordFormat);
    }

    public async Task AssignRoleAsync(Guid userId, AccountRole newRole, Guid? vendorId, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(nameof(userId));

        if (vendorId.HasValue && vendorId.Value != Guid.Empty)
        {
            var vendorAccount = await _vendorAccountRepository.FindSingleAsync(new VendorAccountById(userId, vendorId.Value), cancellationToken);

            if (vendorAccount is null)
            {
                throw new ServiceException($"UserID {userId} is not an user in the vendor of VendorID '{vendorId}'");
            }

            var vendorAccountRole = _mapper.Map<AccountRole>(vendorAccount!.AccountRoles);
            await _userManager.RemoveFromRoleAsync(vendorAccount, vendorAccountRole.GetRole());
            await _userManager.AddToRoleAsync(vendorAccount, newRole.GetRole());

            return;
        }

        var applicationAccount = await _applicationAccountRepository.FindSingleAsync(new ApplicationAccountById(userId), cancellationToken);

        EntityNotFoundException.ThrowIfNotFound(applicationAccount, nameof(applicationAccount));

        var accountRole = _mapper.Map<AccountRole>(applicationAccount!.AccountRoles);
        await _userManager.RemoveFromRoleAsync(applicationAccount, accountRole.GetRole());
        await _userManager.AddToRoleAsync(applicationAccount!, newRole.GetRole());
    }

    public async Task BlockAsync(Guid userId, DateTime? blockUntil, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(nameof(userId));

        if (blockUntil.HasValue && blockUntil <= _clock.UtcNow)
        {
            throw new ServiceException($"The {nameof(blockUntil)} parameter '{blockUntil.Value.ToLongDateString()} {blockUntil.Value.ToLongDateString()}' is in the past.");
        }

        var applicationAccount = await _applicationAccountRepository.FindSingleAsync(new ApplicationAccountById(userId, true), cancellationToken);

        EntityNotFoundException.ThrowIfNotFound(applicationAccount, nameof(applicationAccount));

        applicationAccount!.LockoutEnabled = true;
        applicationAccount!.LockoutEnd = blockUntil;
        await _applicationAccountRepository.UpdateAsync(applicationAccount, cancellationToken: cancellationToken);
    }

    public async Task UnBlockAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(nameof(userId));

        var applicationAccount = await _applicationAccountRepository.FindSingleAsync(new ApplicationAccountById(userId, true), cancellationToken);

        EntityNotFoundException.ThrowIfNotFound(applicationAccount, nameof(applicationAccount));

        applicationAccount!.LockoutEnabled = false;
        applicationAccount!.LockoutEnd = null;
        await _applicationAccountRepository.UpdateAsync(applicationAccount, cancellationToken: cancellationToken);
    }

    public async Task<ApplicationAccountDto> CreateAsync(CreateApplicationAccountDto createApplicationAccountDto, CancellationToken cancellationToken = default)
    {
        var saltKey = _encryptionService.CreateSaltKey(AccountServicesDefaults.PasswordSaltKeySize);
        var password = GeneratePassword();
        var hashedPassword = _encryptionService.CreatePasswordHash(password, saltKey, AccountServicesDefaults.DefaultHashedPasswordFormat);

        var applicationAccount = _mapper.Map<ApplicationAccount>(createApplicationAccountDto);

        var result = await _userManager.CreateAsync(applicationAccount);

        if (!result.Succeeded)
        {
            throw new ServiceException($"Creating a new application account has not succeeded.");
        }

        applicationAccount.PasswordHash = hashedPassword;
        await _userManager.AddToRoleAsync(applicationAccount, createApplicationAccountDto.Role.GetRole());

        //TODO: send an email to the new user.

        return _mapper.Map<ApplicationAccountDto>(applicationAccount);
    }

    public async Task DeleteByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(nameof(userId));

        var applicationAccount = await _applicationAccountRepository.FindSingleAsync(new ApplicationAccountById(userId, true), cancellationToken);

        EntityNotFoundException.ThrowIfNotFound(applicationAccount, nameof(applicationAccount));
        await _applicationAccountRepository.DeleteAsync(userId, cancellationToken);
    }

    public async Task<IPagedList<ApplicationAccountDto>> GetAsync(Guid? vendorId, EntityStatus entityStatus = EntityStatus.Active,
        int pageIndex = 0, int pageSize = int.MaxValue, CancellationToken cancellationToken = default)
    {
        if (vendorId.HasValue && vendorId != Guid.Empty)
        {
            var vendorAccounts = await _vendorAccountRepository.FindAsync(new VendorAccountsByVendorId(vendorId.Value, entityStatus), cancellationToken);

            return new PagedList<ApplicationAccountDto>(_mapper.Map<List<ApplicationAccountDto>>(vendorAccounts), pageIndex, pageSize);
        }

        var applicationAccounts = await _applicationAccountRepository.FindAsync(new ApplicationAccountsList(entityStatus), cancellationToken);

        return new PagedList<ApplicationAccountDto>(_mapper.Map<List<ApplicationAccountDto>>(applicationAccounts), pageIndex, pageSize);
    }

    public async Task<ApplicationAccountDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(nameof(userId));

        var applicationAccount = await _applicationAccountRepository.FindSingleAsync(new ApplicationAccountById(userId, true), cancellationToken);

        EntityNotFoundException.ThrowIfNotFound(applicationAccount, nameof(applicationAccount));

        return _mapper.Map<ApplicationAccountDto>(applicationAccount);
    }

    public async Task<ApplicationAccountDto> UpdateAsync(ApplicationAccountDto applicationAccountDto, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(applicationAccountDto);

        var applicationAccount = await _applicationAccountRepository
            .FindSingleAsync(new ApplicationAccountById(applicationAccountDto!.Id, true), cancellationToken);

        ArgumentNullException.ThrowIfNull(applicationAccount);

        applicationAccount.PhoneNumber = applicationAccountDto.PhoneNumber;
        applicationAccount.FirstName = applicationAccountDto.FirstName;
        applicationAccount.LastName = applicationAccountDto.LastName;
        applicationAccount.UserName = applicationAccountDto.UserName;
        applicationAccount.Email = applicationAccountDto.Email;

        applicationAccount = await _applicationAccountRepository.UpdateAsync(applicationAccount, cancellationToken: cancellationToken);
        return _mapper.Map<ApplicationAccountDto>(applicationAccount);
    }

    #region Helpers

    private static bool IsValidEmail(string email)
    {
        // Regular expression pattern for email validation
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        // Use Regex.IsMatch to check if the email matches the pattern
        return Regex.IsMatch(email, pattern);
    }

    private static string GeneratePassword()
    {
        var password = new StringBuilder("", 16);

        for (var i = 0; i < 5; i++)
        {
            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(48, 58))); // digits

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(97, 123)));  // lowercase

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(65, 91)));  // uppercase

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(33, 48)));  // symbols
        }

        return password.ToString();
    }

    #endregion
}
