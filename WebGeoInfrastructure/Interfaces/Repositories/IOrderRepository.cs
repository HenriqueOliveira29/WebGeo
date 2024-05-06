using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();
        public Task<bool> CreateOrder(Order order);

        public Task<bool> CreateProductOrder(ProductOrder productOrder);


    }
}
