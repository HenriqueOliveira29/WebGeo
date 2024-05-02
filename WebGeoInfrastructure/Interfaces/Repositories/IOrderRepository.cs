using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();


    }
}
