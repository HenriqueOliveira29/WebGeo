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

        public async Task<List<ProductOrder>> GetProductOrdersToReStockFromShop(int id)
        {
            return await _context.ProductOrders.Include(po => po.Order).Where(s => s.Order.ShopId == id && s.Order.State == OrderState.WaitingForStock.ToString()).ToListAsync();
        }

        public async Task<bool> AddProductToShop(ProductShop productShop)
        {
            try
            {
                await _context.ProductShops.AddAsync(productShop);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductShop> UpdateStockProductShop(ProductShop productShop)
        {
            _context.Entry<ProductShop>(productShop).CurrentValues.SetValues(productShop);
            await _context.SaveChangesAsync();
            return productShop;
        }

        public async Task<ProductShop?> GetProductShop(int shopId, int productId)
        {
            return await _context.ProductShops.Include(ps => ps.Product).Include(ps => ps.Shop)
                .Where(ps => ps.Shop.Id == shopId && ps.Product.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<List<ProductShop>> GetProductsOfShop(int shopId)
        {
            return await _context.ProductShops.Include(ps => ps.Product).Include(ps => ps.Shop).Where(ps => ps.Shop.Id == shopId).ToListAsync();
        }

        public async Task<List<Shop>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task<List<Storage>> GetStoragesCloseToShopToReStock(Shop shop, ProductOrder product)
        {
            return await _context.ProductStorages.Include(ps => ps.Product).Include(ps => ps.Storage).Where(s => s.Product.Id == product.ProductId && s.Stock >= product.Quantity).OrderBy(s => s.Storage.Location.Distance(shop.Location)).Select(t => t.Storage).ToListAsync();
        }
    }
}
