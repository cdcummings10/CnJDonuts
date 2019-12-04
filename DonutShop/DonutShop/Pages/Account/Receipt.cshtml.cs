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
        /// <summary>
        /// Takes in the order's ID and grabs the user's email claim and displays the OrderItems associated with the order.
        /// </summary>
        /// <param name="id">Takes in the order's ID.</param>
        public async Task OnGet(int id)
        {
            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
            Order order = await _order.GetOrderForCustomer(id, email);
            OrderItems = await _order.GetOrderItems(id, email);
        }
    }
}