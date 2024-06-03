using Microsoft.EntityFrameworkCore;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Interfaces.Repositories;
namespace WebGeoRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDBContext _context;
        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Include(t => t.Products).Where(t => t.State == OrderState.WaitingForStock.ToString()).OrderBy(t => t.DateDeliver).ToListAsync();
        }

        public async Task<bool> CreateOrder(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateProductOrder(ProductOrder productOrder)
        {
            try
            {
                await _context.ProductOrders.AddAsync(productOrder);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.Include(o => o.ProductOrders).Include(o => o.Products).Include(o => o.Shop).ThenInclude(s => s.ProductShop).Include(t => t.Shop.Locality).FirstOrDefaultAsync();
        }

        public async Task<Order> Update(Order order)
        {
            _context.Entry<Order>(order).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<ProductOrder>> GetProductOrdersToRestock(int id)
        {
            return await _context.ProductOrders.Include(t => t.Order).ThenInclude(t => t.Shop).ThenInclude(t => t.Locality).Where(t => t.OrderId == id && t.InShop == false).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersToRestock()
        {
            return await _context.Orders.Include(t => t.ProductOrders).Where(t => t.ProductOrders.Where(s => s.InShop == false).Any() == true).OrderBy(t => t.Date).ToListAsync();
        }
    }
}
