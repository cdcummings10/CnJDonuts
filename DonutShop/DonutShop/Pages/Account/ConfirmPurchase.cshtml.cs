using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private IPayment _payment;
        private IEmailSender _emailSender;
        private ICart _cart;
        private IOrder _order;

        [BindProperty]
        public Address Address { get; set; }
        [Display(Name = "Credit Card")]
        [BindProperty]
        public string CreditCard { get; set; }

        public ConfirmPurchaseModel(IEmailSender emailSender, ICart cart, IOrder order, IPayment payment)
        {
            _payment = payment;
            _emailSender = emailSender;
            _cart = cart;
            _order = order;
        }
        public void OnGet()
        {

        }
        /// <summary>
        /// Takes in a form and creates an email receipt that is sent to the user. Creates a new order and 
        /// saves it into the database.
        /// </summary>
        /// <returns>Redirects to the saved order.</returns>
        public async Task<IActionResult> OnPost()
        {
            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
            string subject = "Thank you for your purchase!";
            var items = await _cart.GetCartItems(email);
            StringBuilder builder = new StringBuilder();
            decimal total = 0;
            foreach (var item in items)
            {
                builder.Append($"Item: {item.Donut.Name}\n");
                builder.Append($"Quantity: {item.Quantity}\n");
                builder.Append($"Subtotal: {item.Quantity * item.Donut.Price}\n\n");
                total += item.Quantity * item.Donut.Price;
            }
            builder.Append($"Total: {total}");

            //process payment
            _payment.Run(total, Convert.ToInt32(CreditCard), Address);


            //send email receipt
            await _emailSender.SendEmailAsync(email, subject, builder.ToString());

            //create and save new order
            Order order = new Order()
            {
                Email = email
            };
            await _order.CreateOrder(order);
            var savedOrder = await _order.GetOrderForCustomer(order.ID, email);
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