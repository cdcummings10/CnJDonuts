using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    public class ProductController : Controller
    {
        private IInventory<Donut> _context { get; set; }
        public ProductController(IInventory<Donut> context)
        {
            _context = context;
        }
        /// <summary>
        /// Default landing page for products.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var donuts = await _context.GetAll();
            return View(donuts);
        }

    }
}