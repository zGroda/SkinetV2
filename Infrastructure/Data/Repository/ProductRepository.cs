using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            //var productList = await _context.Products.Select(p => new Product
            //{
            //    Name = p.Name,
            //    Description = p.Description,
            //    Price = p.Price,
            //    PictureUrl = p.PictureUrl,
            //    ProductBrandId = p.ProductBrandId,
            //    ProductBrand = p.ProductBrand,
            //    ProductTypeId = p.ProductTypeId,
            //    ProductType = p.ProductType
            //}).ToListAsync();

            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
