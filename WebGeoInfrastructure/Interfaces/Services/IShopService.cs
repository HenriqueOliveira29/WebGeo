using WebGeoInfrastructure.DTOs.Shop;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IShopService
    {
        public Task<MessagingHelper> Create(CreateShopDTO createShop);
    }
}
