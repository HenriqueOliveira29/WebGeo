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
        private readonly IStorageRepository _storageRepository;
        private readonly IRoutesRepository _routesRepository;
        public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository, IShopRepository shopRepository, IProductRepository productRepository, IStorageRepository storageRepository, IRoutesRepository routesRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _shopRepository = shopRepository;
            _productRepository = productRepository;
            _storageRepository = storageRepository;
            _routesRepository = routesRepository;
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
                order.SetDateDeliver(createOrder.DateDeliver);
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

        public async Task<List<OrderListDTO>> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            var response = orders.Select(t => new OrderListDTO(t)).ToList();

            return response;
        }

        private async Task<bool> AddProductToOrder(Product product, Order order, float quantity)
        {

            order.AddProducts(product);
            ProductOrder productOrder = new ProductOrder(product, order, quantity);
            return await _orderRepository.CreateProductOrder(productOrder);
        }

        public async Task<MessagingHelper> ValidateOrder(int id)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                Order? order = await _orderRepository.GetById(id);
                if (order == null)
                {
                    response.Success = false;
                    response.Message = "this order doesn't exist";
                    return response;
                }

                if (order.State != OrderState.Active.ToString())
                {
                    response.Success = false;
                    response.Message = "this order is already validated";
                    return response;
                }

                foreach (ProductOrder product in order.ProductOrders)
                {
                    var ProductInShop = await _shopRepository.GetProductShop(order.ShopId, product.ProductId);
                    if (ProductInShop == null || product.Quantity > ProductInShop.Stock)
                    {
                        order.SetOrderOnWaitingStock();
                        product.SetIsNotInShop();
                    }
                    else
                    {
                        ProductInShop.RetireStock(product.Quantity);
                    }
                }

                await _orderRepository.Update(order);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper> CancelOrder(int id)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var orderExist = await _orderRepository.GetById(id);
                if (orderExist == null)
                {
                    response.Success = false;
                    response.Message = "This order doesn't exist";
                    return response;
                }

                orderExist.Cancel();

                await _orderRepository.Update(orderExist);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper<List<RoutesCordDTO>>> CalculateBestPath(CalculateRouteDTO calculateRoute)
        {
            MessagingHelper<List<RoutesCordDTO>> response = new MessagingHelper<List<RoutesCordDTO>>();
            try
            {
                var order = await _orderRepository.GetById(calculateRoute.OrderId);
                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Esta encomenda não existe";
                    return response;
                }

                var shop = await _shopRepository.GetById(order.ShopId);
                if (shop == null)
                {
                    response.Success = false;
                    response.Message = "Esta loja não existe";
                    return response;
                }

                var locality = await _routesRepository.GetLocalityMostClosed(calculateRoute.EstafetaX, calculateRoute.EstafetaY);
                if (locality == null)
                {
                    response.Success = false;
                    response.Message = "Não foi possivel encontrar a localidade mais perto";
                }

                var storage = await GetBetterRoadToReStock(calculateRoute.EstafetaX, calculateRoute.EstafetaY, order.ShopId);

                var rotaEstafetaStorage = await CalculateRoute(locality, storage.Locality);
                var rotaStorageShop = await CalculateRoute(storage.Locality, shop.Locality);
                List<Locality> routes = new List<Locality>();
                foreach (var local in rotaEstafetaStorage)
                {
                    var route = await _routesRepository.GetById(local);
                    routes.Add(route);
                }
                foreach (var local in rotaStorageShop)
                {
                    var route = await _routesRepository.GetById(local);
                    routes.Add(route);
                }


                List<RoutesCordDTO> result = routes.Select(t => GeometryConverter.GetCoordinates(GeometryConverter.TransformToSrid(t.Location as NetTopologySuite.Geometries.Point, 4326))).ToList();
                response.Obj = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        private async Task<List<int>> CalculateRoute(Locality localityOrigin, Locality localityDestiny)
        {
            List<Routes> routesInDB = await _routesRepository.GetAll();

            Grapth graph = new Grapth(routesInDB);

            var localities = graph.ShortestPath(localityOrigin.Id, localityDestiny.Id);

            return localities;
        }

        private async Task<Storage> GetBetterRoadToReStock(double cordX, double cordY, int orderId)
        {
            Storage storageToReturn = null;
            int pontos = 0;
            var productOrdersToRestock = await _orderRepository.getProductOrdersToRestock(orderId);
            List<Storage> closestStorages = await _shopRepository.GetStoragesCloseToShopToReStock(cordX, cordY);
            if (closestStorages.Count > 0)
            {
                foreach (Storage storage in closestStorages)
                {
                    int pontosStorage = 0;
                    foreach (ProductOrder po in productOrdersToRestock)
                    {
                        var productStorage = await _storageRepository.GetProductStorage(storage.Id, po.ProductId);
                        if (productStorage.Stock > po.Quantity)
                        {
                            pontosStorage += 1;
                        }
                    }
                    if (pontosStorage > pontos)
                    {
                        storageToReturn = storage;
                        pontos = pontosStorage;
                    }
                }
            }

            return storageToReturn;

        }
    }
}
