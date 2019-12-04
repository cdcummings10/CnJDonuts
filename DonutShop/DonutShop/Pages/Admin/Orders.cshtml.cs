using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrdersModel : PageModel
    {
        private IOrder _orders;
        [BindProperty]
        public IEnumerable<Order> OrdersList { get; set; }

        public OrdersModel(IOrder orders)
        {
            _orders = orders;
        }
        public async Task OnGet()
        {
            OrdersList = await _orders.GetAllOrders();
        }
        public IActionResult OnPost(int OrderID)
        {
            return Redirect($"~/Admin/OrderDetails/{OrderID}");
        }
    }
}