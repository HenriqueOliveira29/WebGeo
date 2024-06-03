using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Interfaces.Repositories
{
    public interface IRoutesRepository
    {
        public Task<List<Routes>> GetAll();
        public Task<Locality> GetById(int id);
        public Task<Locality> GetLocalityMostClosed(double cordX, double cordY);
    }
}
