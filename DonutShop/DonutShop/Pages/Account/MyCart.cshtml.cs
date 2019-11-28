using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Account
{
    public class MyCartModel : PageModel
    {
        private ICart _context;

        [BindProperty]
        public IEnumerable<CartItem> Cart { get; set; }

        public MyCartModel(ICart cart)
        {
            _context = cart;
        }
        public async Task OnGet()
        {
            if (User.IsInRole(ApplicationRoles.Member))
            {
                string email = User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
                Cart = await _context.GetCartItems(email);
            }
        }
    }
}