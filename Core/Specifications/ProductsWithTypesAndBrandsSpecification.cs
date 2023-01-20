using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productSpecificationParams) :
            base(x =>
                (string.IsNullOrEmpty(productSpecificationParams.Search) || x.Name.ToLower().Contains(productSpecificationParams.Search)) &&
                (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId) &&
                (!productSpecificationParams.TypeId.HasValue || x.ProductTypeId == productSpecificationParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecificationParams.PageSize * (productSpecificationParams.PageIndex - 1), productSpecificationParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecificationParams.Sort))
            {
                switch (productSpecificationParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
