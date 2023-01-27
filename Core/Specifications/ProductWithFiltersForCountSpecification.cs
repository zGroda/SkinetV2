using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productSpecificationParams) :
            base(x =>
                (string.IsNullOrEmpty(productSpecificationParams.Search) || x.Name.ToLower().Contains(productSpecificationParams.Search)) &&
                (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId) &&
                (!productSpecificationParams.ProductTypeId.HasValue || x.ProductTypeId == productSpecificationParams.ProductTypeId)
            )
        {
        }
    }
}
