using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Interfaces.Repositories;

namespace WebGeoRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {

            _context = context;

        }
        public async Task<bool> Create(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
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
