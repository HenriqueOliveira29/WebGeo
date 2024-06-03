using Microsoft.AspNetCore.Mvc;
using WebGeoInfrastructure.DTOs.Order;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<OrderListDTO>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper> Create(CreateOrderDTO createOrder)
        {
            return await _orderService.CreateOrder(createOrder);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<MessagingHelper> ValidateOrder(int id)
        {
            return await _orderService.ValidateOrder(id);
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<MessagingHelper> CancelOrder(int id)
        {
            return await _orderService.CancelOrder(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper<List<RoutesCordDTO>>> CalculateRoute(CalculateRouteDTO calculateRoute)
        {
            return await _orderService.CalculateBestPath(calculateRoute);
        }
    }
}
