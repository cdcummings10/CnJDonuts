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
    public class MyOrdersModel : PageModel
    {
        private IOrder _orders;
        [BindProperty]
        public IEnumerable<Order> MyOrders { get; set; }
        public MyOrdersModel(IOrder orders)
        {
            _orders = orders;
        }

        public async Task OnGet()
        {
            var allOrders = await _orders.GetAllOrders();

            MyOrders = allOrders.Where(x => x.Email == User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value);

        }
    }
}