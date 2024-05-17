using WebGeoInfrastructure.DTOs.Shop;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IShopService
    {
        public Task<MessagingHelper> Create(CreateShopDTO createShop);
        public Task<MessagingHelper> AddProductToShop(AddProductToShopDTO addProductToShop);

        public Task<MessagingHelper<List<ProductShopListDTO>>> GetProductsOfShop(int shopId);

        public Task<MessagingHelper<List<ShopListDTO>>> GetShops();
    }
}
