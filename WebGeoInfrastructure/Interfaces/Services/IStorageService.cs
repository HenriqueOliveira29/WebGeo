using WebGeoInfrastructure.DTOs.Storage;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IStorageService
    {
        public Task<MessagingHelper> Create(CreateStorageDTO createStorage);
    }
}
