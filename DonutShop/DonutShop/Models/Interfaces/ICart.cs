using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface ICart
    {
        /// <summary>
        /// Generates a new Cart for  new user registering for the site.
        /// </summary>
        /// <param name="cart">Takes in a cart object.</param>
        public Task GenerateCart(Cart cart);
        /// <summary>
        /// Adds an item to a cart. CartItem should already have cartID associated with it.
        /// </summary>
        /// <param name="item">Takes in a CartItem Object</param>
        public Task AddToCart(CartItem item);
        /// <summary>
        /// Removes an item from a cart.
        /// </summary>
        /// <param name="id">Takes in the item's ID to remove it from the cart.</param>
        public Task RemoveFromCart(int id);
        /// <summary>
        /// Updated the quantity of the items in a cart.
        /// </summary>
        /// <param name="item">Takes in the cart item which needs to be updated.</param>
        public Task UpdateQuantity(CartItem item);
        /// <summary>
        /// Gets a cart item based on it's ID
        /// </summary>
        /// <param name="id">Takes in the ID of the item to be gotten.</param>
        /// <returns>Returns the CartItem.</returns>
        public Task<CartItem> GetCartItem(int id);
        /// <summary>
        /// Gets all items associated with a cart by the user's email.
        /// </summary>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns an IEnumerable of CartItems.</returns>
        public Task<IEnumerable<CartItem>> GetCartItems(string email);
        /// <summary>
        /// Gets a cartID based on the user's email.
        /// </summary>
        /// <param name="email">Takes in the user's email.</param>
        /// <returns>Returns the ID of the cart.</returns>
        Task<int> GetCartIDByEmail(string email);
    }
}
