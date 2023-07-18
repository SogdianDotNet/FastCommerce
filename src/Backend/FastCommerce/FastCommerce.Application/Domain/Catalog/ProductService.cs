using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Catalog.Dtos;
using FastCommerce.Application.Domain.Catalog.Interfaces;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Interfaces;

namespace FastCommerce.Application.Domain.Catalog;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IPagedList<ProductDto>> GetByFilter(Guid categoryId, Guid? vendorId, int pageIndex = 0, int pageSize = int.MaxValue, CancellationToken cancellationToken = default)
    {

    }
}
