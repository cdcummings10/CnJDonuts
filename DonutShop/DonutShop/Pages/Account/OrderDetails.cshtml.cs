using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Account
{
    public class OrderDetailsModel : PageModel
    {
        private IOrder _orders;
        [BindProperty]
        public IEnumerable<OrderItem> CurrentOrder { get; set; }

        public OrderDetailsModel(IOrder orders)
        {
            _orders = orders;
        }
        public async Task OnGet(int id)
        {
            Order order = await _orders.GetOrderForAdmin(id);
            CurrentOrder = await _orders.GetOrderItems(order.ID, order.Email);
        }
    }
}