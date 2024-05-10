﻿using Microsoft.AspNetCore.Mvc;
using WebGeoInfrastructure.DTOs.Storage;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<MessagingHelper> Create(CreateStorageDTO createStorage)
        {
            return await _storageService.Create(createStorage);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessagingHelper> AddProductToStorage(AddProductToStorageDTO addProductToStorage)
        {
            return await _storageService.AddProductToStorage(addProductToStorage);
        }
    }
}
