using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IStorageRepository
    {
        public Task<bool> Create(Storage storageCreate);

        public Task<Storage?> GetById(int id);

        public Task<bool> AddProductToStorage(ProductStorage productStorage);

        public Task<ProductStorage?> GetProductStorage(int storageId, int productId);

        public Task<ProductStorage> UpdateStockProductStorage(ProductStorage productShop);

        public Task<List<ProductStorage>> GetProductStorages(int storageId);

        public Task<List<Storage>> GetStorages();
    }
}
