﻿using WebGeoInfrastructure.DTOs.Order;
using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<List<OrderListDTO>> GetOrders();

        public Task<MessagingHelper> CreateOrder(CreateOrderDTO createOrder);

        public Task<MessagingHelper> ValidateOrder(int id);

        public Task<MessagingHelper> CancelOrder(int id);

        public Task<MessagingHelper<OrderDetailDTO>> CalculateBestPath(CalculateRouteDTO calculateRoute);
        public Task<MessagingHelper> DelieverToClient(int orderId);
        public Task<MessagingHelper> DeliverRestockToShop(int orderId);
    }
}
