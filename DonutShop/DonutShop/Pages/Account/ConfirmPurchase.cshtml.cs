using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DonutShop.Models;
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
        private IOrder _order;

        public ConfirmPurchaseModel(IEmailSender emailSender, ICart cart, IOrder order)
        {
            _emailSender = emailSender;
            _cart = cart;
            _order = order;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            //send email receipt
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

            //create and save new order
            Order order = new Order()
            {
                Email = email
            };
            await _order.CreateOrder(order);
            var savedOrder = await _order.GetOrder(order.ID, email);
            foreach (var item in items)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderID = savedOrder.ID,
                    DonutID = item.DonutID,
                    Quantity = item.Quantity
                };
                await _order.CreateOrderItem(orderItem);
                await _cart.RemoveFromCart(item.ID);
            }

            return Redirect($"~/account/receipt/{savedOrder.ID}");
        }
    }
}