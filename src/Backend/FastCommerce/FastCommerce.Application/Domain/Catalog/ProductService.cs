using AutoMapper;
using FastCommerce.Application.Domain.Catalog.Dtos;
using FastCommerce.Application.Domain.Catalog.Interfaces;
using FastCommerce.Application.Domain.Catalog.Specifications;
using FastCommerce.Application.Exceptions;
using FastCommerce.Application.Interfaces;
using FastCommerce.Domain.Common;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Interfaces;

namespace FastCommerce.Application.Domain.Catalog;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IClock _clock;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;

    public ProductService(IRepository<Product> productRepository,
        IRepository<Category> categoryRepository,
        IMapper mapper,
        IClock clock)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _clock = clock;
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetByFilter(
        Guid? categoryId, Guid? vendorId, int pageIndex = 0, int pageSize = int.MaxValue,
        EntityStatus entityStatus = EntityStatus.Active, SortDirection sortDirection = SortDirection.Ascending, 
        bool includeInactive = true, CancellationToken cancellationToken = default)
    {
        if (categoryId.HasValue && categoryId != Guid.Empty)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(categoryId));
            }

            var category = await _categoryRepository.FindSingleAsync(new CategoryById(categoryId!.Value), cancellationToken);

            if (category is null || !category.IsActive)
            {
                throw new InvalidCategoryException($"Category with ID '{categoryId}' is null or inactive");
            }
        }

        var products = await _productRepository.FindAsync(
            new ProductsByFilter(_clock.UtcNow, categoryId, vendorId, pageIndex, pageSize, entityStatus, sortDirection, includeInactive), 
            cancellationToken);

        return _mapper.Map<IReadOnlyCollection<ProductDto>>(products);
    }

    public async Task<ProductDto> SaveAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = _mapper.Map<Product>(dto);

        return _mapper.Map<ProductDto>(await _productRepository.InsertAsync(product, cancellationToken));
    }

    public async Task<ProductDto> UpdateAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.FindSingleAsync(new ProductById(dto!.Id), cancellationToken);

        product!.Name = dto.Name;
        product.Description = dto.Description;
        product.ActiveFrom = dto.ActiveFrom;
        product.ActiveTo = dto.ActiveTo;
        product.Prices = _mapper.Map<ICollection<ProductPrice>>(dto.Prices);
        product.ProductAttributes = _mapper.Map<ICollection<ProductAttribute>>(dto.ProductAttributes);

        if (product.Category!.Id != dto.Category!.Id)
        {
            product.Category = await _categoryRepository.FindSingleAsync(new CategoryById(dto.Category!.Id), cancellationToken);
        }

        return _mapper.Map<ProductDto>(await _productRepository.UpdateAsync(product, cancellationToken: cancellationToken));
    }

    public async Task DeleteAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.FindSingleAsync(new ProductById(productId, false), cancellationToken);
        EntityNotFoundException.ThrowIfNotFound(product, nameof(product));

        await _productRepository.DeleteAsync(productId, cancellationToken);
    }
}
