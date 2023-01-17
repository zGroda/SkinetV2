using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }
        public Task<IReadOnlyList<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
