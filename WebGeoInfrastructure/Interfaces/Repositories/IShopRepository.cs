using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IShopRepository
    {
        public Task<bool> Create(Shop shop);

        public Task<Shop?> GetById(int id);
    }
}
