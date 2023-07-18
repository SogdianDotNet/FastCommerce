using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Catalog.Dtos;

namespace FastCommerce.Application.Domain.Catalog.Interfaces;

public interface IProductService
{
    Task<IPagedList<ProductDto>> GetByFilter(Guid categoryId, Guid? vendorId, int pageIndex = 0, int pageSize = int.MaxValue, CancellationToken cancellationToken = default);
}
