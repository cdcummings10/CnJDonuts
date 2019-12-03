using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private IInventory<Donut> _context;
        [BindProperty]
        public Donut Donut { get; set; }

        public DetailsModel(IInventory<Donut> context)
        {
            _context = context;
        }
        /// <summary>
        /// On load, takes in an ID and displays product details for the specific donut.
        /// </summary>
        /// <param name="id">Takes in the donut ID.</param>
        public async Task OnGet(int id)
        {
            Donut = await _context.GetByID(id);
        }
    }
}