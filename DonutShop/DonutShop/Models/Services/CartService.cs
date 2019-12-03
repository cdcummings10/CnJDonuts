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
        /// <summary>
        /// Adds an item to a cart. CartItem should already have cartID associated with it.
        /// </summary>
        /// <param name="item">Takes in a CartItem Object</param>
        public async Task AddToCart(CartItem item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

        }
        /// <summary>
        /// Generates a new Cart for  new user registering for the site.
        /// </summary>
        /// <param name="cart">Takes in a cart object.</param>
        public async Task GenerateCart(Cart cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets a cart item based on it's ID
        /// </summary>
        /// <param name="id">Takes in the ID of the item to be gotten.</param>
        /// <returns>Returns the CartItem.</returns>
        public async Task<CartItem> GetCartItem(int id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(x => x.ID == id);
        }
        /// <summary>
        /// Gets all items associated with a cart by the user's email.
        /// </summary>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns an IEnumerable of CartItems.</returns>
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
        /// <summary>
        /// Removes an item from a cart.
        /// </summary>
        /// <param name="id">Takes in the item's ID to remove it from the cart.</param>
        public async Task RemoveFromCart(int id)
        {
            CartItem item = await GetCartItem(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Updated the quantity of the items in a cart.
        /// </summary>
        /// <param name="item">Takes in the cart item which needs to be updated.</param>
        public async Task UpdateQuantity(CartItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets a cartID based on the user's email.
        /// </summary>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns the ID of the cart.</returns>
        public async Task<int> GetCartIDByEmail(string email)
        {
            int cartID = (await _context.Carts.FirstOrDefaultAsync(x => x.UserEmail == email)).ID;
            return cartID;
        }
    }
}
