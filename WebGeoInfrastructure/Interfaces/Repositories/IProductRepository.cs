using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<bool> Create(Product product);
    }
}
