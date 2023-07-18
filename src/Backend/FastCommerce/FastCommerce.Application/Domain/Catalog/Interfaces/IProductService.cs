using FastCommerce.Application.Domain.Catalog.Dtos;
using FastCommerce.Domain.Common;
using FastCommerce.Domain.Entities.Common.Enums;

namespace FastCommerce.Application.Domain.Catalog.Interfaces;

public interface IProductService
{
    Task<IReadOnlyCollection<ProductDto>> GetByFilter(
        Guid? categoryId, Guid? vendorId, int pageIndex = 0, int pageSize = int.MaxValue,
        EntityStatus entityStatus = EntityStatus.Active, SortDirection sortDirection = SortDirection.Ascending,
        bool includeInactive = true, CancellationToken cancellationToken = default);

    Task<ProductDto> SaveAsync(ProductDto dto, CancellationToken cancellationToken = default);

    Task<ProductDto> UpdateAsync(ProductDto dto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid productId, CancellationToken cancellationToken = default);
}
