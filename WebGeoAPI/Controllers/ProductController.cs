using Microsoft.AspNetCore.Mvc;
using WebGeoInfrastructure.DTOs.Product;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper> Create(ProductCreateDTO productCreate)
        {
            return await _productService.Create(productCreate);
        }
    }
}
