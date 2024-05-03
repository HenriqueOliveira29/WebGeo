using WebGeoInfrastructure.DTOs.Client;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Helpers;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;

namespace WebGeo.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<MessagingHelper<List<ClientListDTO>>> GetAll()
        {
            MessagingHelper<List<ClientListDTO>> response = new MessagingHelper<List<ClientListDTO>>();
            try
            {
                List<Client> orderList = await _clientRepository.GetAll();

                response.Success = true;
                response.Obj = orderList.Select(t => new ClientListDTO(t)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper<ClientDetailDTO?>> GetById(int id)
        {
            MessagingHelper<ClientDetailDTO?> response = new MessagingHelper<ClientDetailDTO?>();
            try
            {
                var client = await _clientRepository.GetById(id);
                if (client == null)
                {
                    response.Success = false;
                    response.Message = "Este cliente não existe";
                    return response;
                }
                response.Success = true;
                response.Obj = new ClientDetailDTO(client);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<MessagingHelper> Insert(ClientInsertDTO clientInsert)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var create = await _clientRepository.Insert(clientInsert.toEntity());
                if (!create)
                {
                    response.Message = "Ocorreu um erro ao criar o cliente";
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
