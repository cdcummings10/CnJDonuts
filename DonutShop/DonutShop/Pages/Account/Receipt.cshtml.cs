using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Account
{
    public class ReceiptModel : PageModel
    {
        private IOrder _order;
        [BindProperty]
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public ReceiptModel(IOrder order)
        {
            _order = order;
        }
        public async Task OnGet(int id)
        {
            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
            Order order = await _order.GetOrder(id, email);
            OrderItems = await _order.GetOrderItems(id, email);
        }
    }
}