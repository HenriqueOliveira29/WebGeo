using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IShopRepository
    {
        public Task<bool> Create(Shop shop);

        public Task<Shop?> GetById(int id);

        public Task<List<Shop>> GetShops();

        public Task<bool> AddProductToShop(ProductShop productShop);

        public Task<ProductShop> UpdateStockProductShop(ProductShop productShop);

        public Task<ProductShop?> GetProductShop(int shopId, int productId);

        public Task<List<ProductShop>> GetProductsOfShop(int shopId);

        public Task<List<ProductOrder>> GetProductOrdersToReStockFromShop(int id);

        public Task<List<Storage>> GetStoragesCloseToShopToReStock(double cordX, double cordY);
    }
}
