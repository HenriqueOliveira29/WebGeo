using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrders();
    }
}
