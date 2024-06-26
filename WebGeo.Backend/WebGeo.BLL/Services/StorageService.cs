﻿using WebGeoInfrastructure.DTOs.Storage;
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
                    var update = await _storageRepository.UpdateProductStorage(productStorageExist);
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

        public async Task<MessagingHelper<List<ProductStorageListDTO>>> GetProductsOfStorage(int storageId)
        {
            MessagingHelper<List<ProductStorageListDTO>> response = new MessagingHelper<List<ProductStorageListDTO>>();
            try
            {
                var list = await _storageRepository.GetProductStorages(storageId);
                response.Obj = list.Select(ps => new ProductStorageListDTO(storageId, ps.Product.Name, ps.Product.Description, ps.Stock)).ToList();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper<List<StorageListDTO>>> GetStorages()
        {
            MessagingHelper<List<StorageListDTO>> response = new MessagingHelper<List<StorageListDTO>>();
            try
            {
                var list = await _storageRepository.GetStorages();
                response.Obj = list.Select(s => new StorageListDTO(s.Id, "")).ToList();
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
