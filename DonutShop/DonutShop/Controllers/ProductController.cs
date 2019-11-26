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

        /// <summary>
        /// Takes in an ID sent from a front end form and redirects to a details page for the specific ID.
        /// </summary>
        /// <param name="ID">Takes in the ID of the product to be displayed.</param>
        /// <returns>Redirects to product details of the ID.</returns>
        [HttpPost]
        public IActionResult Index(int ID)
        {
            return Redirect($"~/product/details/{ID}");
        }

    }
}