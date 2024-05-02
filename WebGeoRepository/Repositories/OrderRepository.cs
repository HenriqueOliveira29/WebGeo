﻿using Microsoft.EntityFrameworkCore;
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
            return await _context.Orders.ToListAsync();
        }
    }
}
