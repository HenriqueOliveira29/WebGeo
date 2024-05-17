using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<bool> Create(Product product);

        public Task<Product?> GetById(int Id);
    }
}
