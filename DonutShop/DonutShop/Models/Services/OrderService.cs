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
        /// <summary>
        /// Creates a new Order in the database.
        /// </summary>
        /// <param name="order">Takes in the order object.</param>
        public async Task CreateOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Adds a new OrderItem to the database.
        /// </summary>
        /// <param name="orderItem">Takes in the OrderItem to be added.</param>
        public async Task CreateOrderItem(OrderItem orderItem)
        {
            await _context.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(x => x.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> GetOrderForAdmin(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x =>x.ID == id);
        }

        /// <summary>
        /// Gets order based on the order's ID and the user's email.
        /// </summary>
        /// <param name="orderID">Takes in the order's ID</param>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns the specific Order.</returns>
        public async Task<Order> GetOrderForCustomer(int orderID, string email)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Email == email && x.ID == orderID);
        }
        /// <summary>
        /// Gets all items associated with an order. Order is retrieved by the orderID and the user's email.
        /// </summary>
        /// <param name="orderID">Takes in the ID of the order.</param>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns an enumerable of OrderItems.</returns>
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
