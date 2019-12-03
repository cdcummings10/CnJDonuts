using DonutShop.Data;
using DonutShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Services
{
    public class OrderService : IOrder
    {
        private InventoryDbContext _context;

        public OrderService(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrderItem(OrderItem orderItem)
        {
            await _context.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int orderID, string email)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Email == email && x.ID == orderID);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(int orderID, string email)
        {
            var orderItems = await _context.OrderItems
                .Where(x => x.Order.Email == email && x.OrderID == orderID)
                .Include(x => x.Donut)
                .Include(x => x.Order)
                .ToListAsync();
            return orderItems;
        }
    }
}
