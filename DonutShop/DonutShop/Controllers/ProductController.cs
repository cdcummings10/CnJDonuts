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
        private ICart _cart;
        private IInventory<Donut> _inventory { get; set; }
        public ProductController(IInventory<Donut> context, ICart cart)
        {
            _inventory = context;
            _cart = cart;
        }
        /// <summary>
        /// Default landing page for products.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var donuts = await _inventory.GetAll();
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

        /// <summary>
        /// Shows the creation of a new product screen.
        /// </summary>
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        /// <summary>
        /// Taks in a donut item and adds the donut to the inventory database.
        /// </summary>
        /// <param name="donut">Takes in a new donut object</param>
        /// <returns>Returns to the detail page of the new donut.</returns>
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(Donut donut)
        {
            if (ModelState.IsValid)
            {
                await _inventory.Create(donut);
                return Redirect($"~/product/details/{donut.ID}");
            }
            return View();
        }

        /// <summary>
        /// Redirects to the edit page, by taking in an ID.
        /// </summary>
        /// <param name="id">Takes in the database ID of the donut selected.</param>
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int id)
        {
            Donut donut = await _inventory.GetByID(id);
            return View(donut);
        }
        /// <summary>
        /// Takes in a donut that has been editted and updated the database.
        /// </summary>
        /// <param name="donut">Takes in an editted donut.</param>
        /// <returns>On successful edit, returns to the details page of the editted donut.</returns>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Edit(Donut donut)
        {
            if (ModelState.IsValid)
            {
                await _inventory.Update(donut);
                return Redirect($"~/product/details/{donut.ID}");
            }
            return View(donut);
        }

        /// <summary>
        /// Shows the deletion confirmation screen.
        /// </summary>
        /// <param name="id">Takes in the donut's database ID that needs to be deleted.</param>
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            Donut donut = await _inventory.GetByID(id);
            return View(donut);
        }
        /// <summary>
        /// Takes in a donut and deletes it from the database.
        /// </summary>
        /// <param name="donut">Takes in the donut to be deleted.</param>
        /// <returns>Redirects the user back to the index.</returns>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Delete(Donut donut)
        {
            await _inventory.Delete(donut.ID);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Takes in a email, an ID of a donut and the quantity. Creates a new cartitem and adds it to the user's cart.
        /// </summary>
        /// <param name="Value">Takes in the email claim as a string of the user.</param>
        /// <param name="donutID">Takes in the int ID of the donut to be added.</param>
        /// <param name="quantity">Takes in the quantity of the donuts to be added.</param>
        /// <returns>Redirects to the user's cart upon successful addition.</returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(string Value, int donutID, int quantity)
        {
            int cartID = await _cart.GetCartIDByEmail(Value);
            CartItem cartItem = new CartItem()
            {
                CartID = cartID,
                DonutID = donutID,
                Quantity = quantity
            };
            await _cart.AddToCart(cartItem);

            return Redirect("~/account/mycart");
        }
    }
}