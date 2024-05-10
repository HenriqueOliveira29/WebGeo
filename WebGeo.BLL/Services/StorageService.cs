using WebGeoInfrastructure.DTOs.Storage;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeo.BLL.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IProductRepository _productRepository;
        public StorageService(IStorageRepository storageRepository, IProductRepository productRepository)
        {

            _storageRepository = storageRepository;
            _productRepository = productRepository;
        }

        public async Task<MessagingHelper> AddProductToStorage(AddProductToStorageDTO addProductToStorage)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var storage = await _storageRepository.GetById(addProductToStorage.StorageId);
                if (storage == null)
                {
                    response.Success = false;
                    response.Message = "This shop doesn't exist";
                    return response;
                }
                var product = await _productRepository.GetById(addProductToStorage.ProductId);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "This product doesn't exist";
                    return response;
                }

                var productStorageExist = await _storageRepository.GetProductStorage(storage.Id, product.Id);
                if (productStorageExist == null)
                {
                    ProductStorage productShop = new ProductStorage(storage, product, addProductToStorage.quantity);
                    var create = await _storageRepository.AddProductToStorage(productShop);
                    if (!create)
                    {
                        response.Success = false;
                        response.Message = "Can´t insert this product";
                    }
                }
                else
                {
                    productStorageExist.AddStock(addProductToStorage.quantity);
                    var update = await _storageRepository.UpdateStockProductStorage(productStorageExist);
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

        public async Task<MessagingHelper> Create(CreateStorageDTO createStorage)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var create = await _storageRepository.Create(createStorage.toEntity());
                if (!create)
                {
                    response.Success = false;
                    response.Message = "Cannot create this storage";
                    return response;
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
    }
}
