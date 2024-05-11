using WebGeoInfrastructure.DTOs.Shop;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeo.BLL.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IProductRepository _productRepository;
        public ShopService(IShopRepository shopRepository, IProductRepository productRepository)
        {
            _shopRepository = shopRepository;
            _productRepository = productRepository;
        }

        public async Task<MessagingHelper> Create(CreateShopDTO createShop)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var create = await _shopRepository.Create(createShop.toEntity());
                if (!create)
                {
                    response.Success = false;
                    response.Message = "Cannot insert this Shop";
                    return response;
                }

                response.Success = create;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper> AddProductToShop(AddProductToShopDTO addProductToShop)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var shop = await _shopRepository.GetById(addProductToShop.ShopId);
                if (shop == null)
                {
                    response.Success = false;
                    response.Message = "This shop doesn't exist";
                    return response;
                }
                var product = await _productRepository.GetById(addProductToShop.ProductId);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "This product doesn't exist";
                    return response;
                }

                var productShopExist = await _shopRepository.GetProductShop(shop.Id, product.Id);
                if (productShopExist == null)
                {
                    ProductShop productShop = new ProductShop(shop, product, addProductToShop.quantity);
                    var create = await _shopRepository.AddProductToShop(productShop);
                    if (!create)
                    {
                        response.Success = false;
                        response.Message = "Can´t insert this product";
                    }
                }
                else
                {
                    productShopExist.AddStock(addProductToShop.quantity);
                    var update = await _shopRepository.UpdateStockProductShop(productShopExist);
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

        public async Task<MessagingHelper<List<ProductShopListDTO>>> GetProductsOfShop(int shopId)
        {
            MessagingHelper<List<ProductShopListDTO>> response = new MessagingHelper<List<ProductShopListDTO>>();
            try
            {
                var list = await _shopRepository.GetProductsOfShop(shopId);
                response.Obj = list.Select(x => new ProductShopListDTO(x.Product.Id, x.Product.Name, x.Product.Description, x.Stock)).ToList();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper<List<ShopListDTO>>> GetShops()
        {
            MessagingHelper<List<ShopListDTO>> response = new MessagingHelper<List<ShopListDTO>>();
            try
            {
                var list = await _shopRepository.GetShops();
                response.Obj = list.Select(x => new ShopListDTO(x.Id, "")).ToList();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper<List<Storage>>> GetBetterRoadToReStock(int shopId)
        {
            MessagingHelper<List<Storage>> response = new MessagingHelper<List<Storage>>();
            try
            {
                List<Storage> storages = new List<Storage>();
                var shop = await _shopRepository.GetById(shopId);
                if (shop == null)
                {
                    response.Success = false;
                    response.Message = "This shop doesn´t exist";
                    return response;
                }

                var productOrdersToRestock = await _shopRepository.GetProductOrdersToReStockFromShop(shopId);
                foreach (ProductOrder po in productOrdersToRestock)
                {
                    List<Storage> closestStorages = await _shopRepository.GetStoragesCloseToShopToReStock(shop, po);
                    if (closestStorages.Count > 0)
                    {
                        storages.Add(closestStorages[0]);
                    }
                }
                response.Success = true;
                response.Obj = storages;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
