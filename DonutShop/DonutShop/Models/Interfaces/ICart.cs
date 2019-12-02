using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface ICart
    {
        public Task GenerateCart(Cart cart);
        public Task AddToCart(CartItem item);
        public Task RemoveFromCart(int id);
        public Task UpdateQuantity(CartItem item);
        public Task<CartItem> GetCartItem(int id);
        public Task<IEnumerable<CartItem>> GetCartItems(string email);
        Task<int> GetCartIDByEmail(string email);
    }
}
