using WebGeoInfrastructure.DTOs.Storage;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IStorageService
    {
        public Task<MessagingHelper> Create(CreateStorageDTO createStorage);

        public Task<MessagingHelper> AddProductToStorage(AddProductToStorageDTO addProductToStorage);

        public Task<MessagingHelper<List<ProductStorageListDTO>>> GetProductsOfStorage(int storageId);

        public Task<MessagingHelper<List<StorageListDTO>>> GetStorages();
    }
}
