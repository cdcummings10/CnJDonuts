using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Components
{
    public class MiniCart : ViewComponent
    {
        private ICart _cart;

        public MiniCart(ICart cart)
        {
            _cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync(string email)
        {
            if (email != null)
            {
                var cart = await _cart.GetCartItems(email);
                return View(cart);
            }
            return View();
        }
    }

}
