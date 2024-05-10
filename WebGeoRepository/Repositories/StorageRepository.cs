using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddProductToStorage(ProductStorage productStorage)
        {
            try
            {
                await _context.ProductStorages.AddAsync(productStorage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Storage?> GetById(int id)
        {
            return await _context.Storages.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductStorage?> GetProductStorage(int storageId, int productId)
        {
            return await _context.ProductStorages.Include(ps => ps.Product).Include(ps => ps.Storage).Where(ps => ps.Product.Id == productId && ps.Storage.Id == storageId).FirstOrDefaultAsync();
        }

        public async Task<ProductStorage> UpdateStockProductStorage(ProductStorage productStorage)
        {
            _context.Entry<ProductStorage>(productStorage).CurrentValues.SetValues(productStorage);
            await _context.SaveChangesAsync();
            return productStorage;
        }
    }
}
