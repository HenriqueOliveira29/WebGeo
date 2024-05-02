using WebGeoInfrastructure.DTOs.Client;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IClientService
    {
        public Task<MessagingHelper<List<ClientListDTO>>> GetAll();

        public Task<MessagingHelper> Insert(ClientInsertDTO clientInsert);

        public Task<MessagingHelper<ClientDetailDTO>> GetById(int id);
    }
}
