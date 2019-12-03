using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Account
{
    public class ConfirmPurchaseModel : PageModel
    {
        private IEmailSender _emailSender;
        private ICart _cart;
        public ConfirmPurchaseModel(IEmailSender emailSender, ICart cart)
        {
            _emailSender = emailSender;
            _cart = cart;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            StringBuilder builder = new StringBuilder();
            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
            string subject = "Thank you for your purchase!";
            var items = await _cart.GetCartItems(email);

            decimal total = 0;
            foreach(var item in items)
            {
                builder.Append($"Item: {item.Donut.Name}\n");
                builder.Append($"Quantity: {item.Quantity}\n");
                builder.Append($"Subtotal: {item.Quantity * item.Donut.Price}\n\n");
                total += item.Quantity * item.Donut.Price;
            }
            builder.Append($"Total: {total}");


            await _emailSender.SendEmailAsync(email, subject, builder.ToString());

            return Page();
        }
    }
}