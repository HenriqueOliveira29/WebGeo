using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IClientRepository
    {
        public Task<bool> Insert(Client client);
        public Task<List<Client>> GetAll();
        public Task<Client> Edit(Client client);
        public Task<Client?> GetById(int id);
    }
}
