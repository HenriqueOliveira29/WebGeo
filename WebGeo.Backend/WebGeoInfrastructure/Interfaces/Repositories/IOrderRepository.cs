using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();
        public Task<bool> CreateOrder(Order order);

        public Task<bool> CreateProductOrder(ProductOrder productOrder);

        public Task<Order?> GetById(int id);

        public Task<Order> Update(Order order);
        public Task<List<ProductOrder>> GetProductOrdersToRestock(int id);

        public Task<List<Order>> GetOrdersToRestock();

        public Task<ProductStorage> UpdateProductStorage(ProductStorage productStorage);
    }
}
