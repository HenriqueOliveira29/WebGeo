using Microsoft.AspNetCore.Mvc;
using WebGeo.BLL.Services;
using WebGeoInfrastructure.DTOs.Order;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;

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

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper> Create(CreateOrderDTO createOrder)
        {
            return await _orderService.CreateOrder(createOrder);
        }
    }
}
