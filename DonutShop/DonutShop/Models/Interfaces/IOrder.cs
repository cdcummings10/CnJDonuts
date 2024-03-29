﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// Creates a new Order in the database.
        /// </summary>
        /// <param name="order">Takes in the order object.</param>
        Task CreateOrder(Order order);
        /// <summary>
        /// Adds a new OrderItem to the database.
        /// </summary>
        /// <param name="orderItem">Takes in the OrderItem to be added.</param>
        Task CreateOrderItem(OrderItem orderItem);
        /// <summary>
        /// Gets order based on the order's ID and the user's email.
        /// </summary>
        /// <param name="orderID">Takes in the order's ID</param>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns the specific Order.</returns>
        Task<Order> GetOrderForCustomer(int orderID, string email);
        /// <summary>
        /// Gets an order only based on an ID. Used for admin purposes only.
        /// </summary>
        /// <param name="id">Takes in the order's ID</param>
        /// <returns>Returns the order.</returns>
        Task<Order> GetOrderForAdmin(int id);
        /// <summary>
        /// Gets all items associated with an order. Order is retrieved by the orderID and the user's email.
        /// </summary>
        /// <param name="orderID">Takes in the ID of the order.</param>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns an enumerable of OrderItems.</returns>
        Task<IEnumerable<OrderItem>> GetOrderItems(int orderID, string email);
        /// <summary>
        /// Grabs all orders from the database, regardless of user. For Admins.
        /// </summary>
        /// <returns>Returns a list of all orders in the database.</returns>
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
