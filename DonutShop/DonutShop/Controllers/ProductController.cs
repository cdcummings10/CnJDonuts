using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(Donut donut)
        {
            if (ModelState.IsValid)
            {
                await _context.Create(donut);
                return Redirect($"~/product/details/{donut.ID}");
            }
            return View();
        }


        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int id)
        {
            Donut donut = await _context.GetByID(id);
            return View(donut);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Edit(Donut donut)
        {
            if (ModelState.IsValid)
            {
                await _context.Update(donut);
                return Redirect($"~/product/details/{donut.ID}");
            }
            return View(donut);
        }


        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            Donut donut = await _context.GetByID(id);
            return View(donut);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Delete(Donut donut)
        {
            await _context.Delete(donut.ID);
            return RedirectToAction("Index");
        }
    }
}