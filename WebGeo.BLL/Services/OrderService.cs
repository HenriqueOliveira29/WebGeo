using WebGeoInfrastructure.DTOs.Order;
using WebGeoInfrastructure.DTOs.Product;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeo.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository, IShopRepository shopRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _shopRepository = shopRepository;
            _productRepository = productRepository;
        }

        public async Task<MessagingHelper> CreateOrder(CreateOrderDTO createOrder)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var client = await _clientRepository.GetById(createOrder.CliendId);
                if (client == null)
                {
                    response.Success = false;
                    response.Message = "This client doesn't exist";
                    return response;
                }

                var shop = await _shopRepository.GetById(createOrder.ShopId);

                if (shop == null)
                {
                    response.Success = false;
                    response.Message = "This shop doesn't exist";
                    return response;
                }

                Order order = new Order(shop, client);
                var create = await _orderRepository.CreateOrder(order);
                if (!create)
                {
                    response.Success = false;
                    response.Message = "Cannot insert this order";
                    return response;
                }

                foreach (ProductListDTO product in createOrder.Products)
                {
                    var productExist = await _productRepository.GetById(product.Id);
                    if (productExist == null)
                    {
                        response.Success = false;
                        response.Message = $"Product with id {product.Id} doesn't exist";
                        return response;
                    }
                    var addProduct = AddProductToOrder(productExist, order, product.Quantity);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        private async Task<bool> AddProductToOrder(Product product, Order order, float quantity)
        {

            order.Products.Add(product);
            ProductOrder productOrder = new ProductOrder(product, order, quantity);
            return await _orderRepository.CreateProductOrder(productOrder);
        }
    }
}
