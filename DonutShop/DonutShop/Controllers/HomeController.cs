using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    public class HomeController : Controller
    {
        private IInventory<Donut> _context;

        public HomeController(IInventory<Donut> context)
        {
            _context = context;
        }
        /// <summary>
        /// Start page and default landing page.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(ApplicationRoles.Admin))
            {
                return Redirect("~/Admin/Portal");
            }
            var donuts = await _context.GetAll();
            return View(donuts);
        }
    }
}