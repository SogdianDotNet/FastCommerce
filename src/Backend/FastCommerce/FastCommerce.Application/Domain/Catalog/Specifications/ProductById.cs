using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

internal class ProductById : Specification<Product>
{
    private readonly Guid _productId;

    public ProductById(Guid productId, bool addIncludes = true)
    {
        _productId = productId;

        if (addIncludes)
        {
            AddInclude(x => x.Category!);
            AddInclude(x => x.ProductAttributes!);
            AddInclude(x => x.Prices!);
        }
    }

    public override Expression<Func<Product, bool>> Criteria => entity => entity.Id == _productId;
}
