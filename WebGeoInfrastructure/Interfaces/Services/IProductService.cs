using WebGeoInfrastructure.DTOs.Product;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IProductService
    {
        public Task<MessagingHelper> Create(ProductCreateDTO productCreate);
    }
}
