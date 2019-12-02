using DonutShop.Data;
using DonutShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Services
{
    public class CartService : ICart
    {
        private InventoryDbContext _context;

        public CartService(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task AddToCart(CartItem item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

        }

        public async Task GenerateCart(Cart cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(string email)
        {
            int cartID = await GetCartIDByEmail(email);

            if (cartID <= 0)
            {
                return null;
            }

            return await _context.CartItems.Where(x => x.CartID == cartID)
                .Include(x => x.Donut)
                .ToListAsync();
        }

        public async Task RemoveFromCart(int id)
        {
            CartItem item = await GetCartItem(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuantity(CartItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCartIDByEmail(string email)
        {
            int cartID = (await _context.Carts.FirstOrDefaultAsync(x => x.UserEmail == email)).ID;
            return cartID;
        }
    }
}
