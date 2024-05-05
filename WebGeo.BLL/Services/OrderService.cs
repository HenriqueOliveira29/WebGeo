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

                List<Product> products = new List<Product>();

                foreach (ProductListDTO product in createOrder.Products)
                {
                    var productExist = await _productRepository.GetById(product.Id);
                    if (productExist == null)
                    {
                        response.Success = false;
                        response.Message = $"Product with id {product.Id} doesn't exist";
                        return response;
                    }
                    products.Add(productExist);
                }

                Order order = new Order();





            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
    }
}
