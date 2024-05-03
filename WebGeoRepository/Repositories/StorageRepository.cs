using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Interfaces.Repositories;

namespace WebGeoRepository.Repositories
{
    public class StorageRepository : IStorageRepository
    {

        private readonly AppDBContext _context;
        public StorageRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Storage storageCreate)
        {
            try
            {
                await _context.Storages.AddAsync(storageCreate);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
