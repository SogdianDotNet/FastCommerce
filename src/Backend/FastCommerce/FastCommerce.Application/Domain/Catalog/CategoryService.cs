using AutoMapper;
using FastCommerce.Application.Domain.Catalog.Dtos;
using FastCommerce.Application.Domain.Catalog.Interfaces;
using FastCommerce.Application.Domain.Catalog.Specifications;
using FastCommerce.Application.Exceptions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Interfaces;

namespace FastCommerce.Application.Domain.Catalog;

public sealed class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<CategoryDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryRepository.FindAsync(new ActiveCategories(), cancellationToken);

        return _mapper.Map<IReadOnlyCollection<CategoryDto>>(categories);
    }

    public async Task DeactivateAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException(nameof(categoryId));
        }

        var category = await _categoryRepository.FindSingleAsync(new CategoryById(categoryId), cancellationToken);
        EntityNotFoundException.ThrowIfNotFound(category, nameof(category));

        category!.IsActive = false;
        category.EntityStatus = EntityStatus.Archived;

        await _categoryRepository.UpdateAsync(category, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException(nameof(categoryId));
        }

        var category = await _categoryRepository.FindSingleAsync(new CategoryById(categoryId), cancellationToken);
        EntityNotFoundException.ThrowIfNotFound(category, nameof(category));

        category!.IsActive = false;
        category.EntityStatus = EntityStatus.Archived;

        await _categoryRepository.UpdateAsync(category, cancellationToken: cancellationToken);
        await _categoryRepository.DeleteAsync(categoryId, cancellationToken: cancellationToken);
    }

    public async Task<CategoryDto> SaveAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(categoryDto);
        if (await _categoryRepository.AnyAsync(new AnyCategoryNameExist(categoryDto?.Name), cancellationToken))
        {
            throw new EntityAlreadyExistsException(categoryDto?.Name);
        }

        var newCategory = await _categoryRepository.InsertAsync(_mapper.Map<Category>(categoryDto), cancellationToken);

        return _mapper.Map<CategoryDto>(newCategory);
    }

    public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDtoToUpdate, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(categoryDtoToUpdate);

        if (categoryDtoToUpdate!.Id == Guid.Empty)
        {
            throw new ArgumentException(nameof(categoryDtoToUpdate.Id));
        }

        var category = await _categoryRepository.FindSingleAsync(new CategoryById(categoryDtoToUpdate!.Id), cancellationToken);
        EntityNotFoundException.ThrowIfNotFound(category, nameof(category));

        if (await _categoryRepository.AnyAsync(new AnyCategoryNameExist(categoryDtoToUpdate?.Name, categoryDtoToUpdate!.Id), cancellationToken))
        {
            throw new EntityAlreadyExistsException(categoryDtoToUpdate?.Name);
        }

        category!.Name = categoryDtoToUpdate.Name;
        category.Description = categoryDtoToUpdate.Description;
        category.IsActive = categoryDtoToUpdate.IsActive;
        category.EntityStatus = categoryDtoToUpdate.EntityStatus;

        return _mapper.Map<CategoryDto>(await _categoryRepository.UpdateAsync(category, cancellationToken: cancellationToken));
    }
}
