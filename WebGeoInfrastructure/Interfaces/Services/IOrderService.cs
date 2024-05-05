using WebGeoInfrastructure.DTOs.Order;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrders();

        public Task<MessagingHelper> CreateOrder(CreateOrderDTO createOrder);
    }
}
