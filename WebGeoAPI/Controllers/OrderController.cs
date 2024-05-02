using Microsoft.AspNetCore.Mvc;
using WebGeo.BLL.Services;
using WebGeoInfrastructure.Entities;

namespace WebGeoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderService.GetOrders();
        }
    }
}
