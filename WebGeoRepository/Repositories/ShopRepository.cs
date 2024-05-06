using Microsoft.EntityFrameworkCore;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Interfaces.Repositories;

namespace WebGeoRepository.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDBContext _context;
        public ShopRepository(AppDBContext context)
        {

            _context = context;
        }

        public async Task<bool> Create(Shop shop)
        {
            try
            {
                await _context.AddAsync(shop);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Shop?> GetById(int id)
        {
            return await _context.Shops.Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
