using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface IOrder
    {
        Task CreateOrder(Order order);
        Task CreateOrderItem(OrderItem orderItem);
        Task<Order> GetOrder(int orderID, string email);
        Task<IEnumerable<OrderItem>> GetOrderItems(int orderID, string email);
    }
}
