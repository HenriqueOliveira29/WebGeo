using Microsoft.AspNetCore.Mvc;
using WebGeoInfrastructure.DTOs.Shop;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeoAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<MessagingHelper> Create(CreateShopDTO createShop)
        {
            return await _shopService.Create(createShop);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper> AddProductShop(AddProductToShopDTO addProductToShop)
        {
            return await _shopService.AddProductToShop(addProductToShop);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<MessagingHelper<List<ProductShopListDTO>>> GetProductsOfShop(int id)
        {
            return await _shopService.GetProductsOfShop(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<MessagingHelper<List<ShopListDTO>>> Index()
        {
            return await _shopService.GetShops();
        }


    }
}
