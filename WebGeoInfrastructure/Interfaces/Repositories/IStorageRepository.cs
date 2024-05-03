using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IStorageRepository
    {
        public Task<bool> Create(Storage storageCreate);
    }
}
