using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace DonutShop.Models.Services
{
    public class EmailService : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Overrides the IEmailSender method SendEmailAsync which takes in an email, subject and message
        /// and converts it into a SendGrid email and sends it.
        /// </summary>
        /// <param name="email">Takes in the recipient email address.</param>
        /// <param name="subject">Takes in the subject of the email.</param>
        /// <param name="htmlMessage">Takes in the message in a string format.</param>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["SendGridEmail"]);
            SendGridMessage message = new SendGridMessage();
            message.SetFrom("DoNotReply@CnJDonuts.com", "C&J Donuts");
            message.AddTo(email);
            message.SetSubject(subject);
            message.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(message);
        }
    }
}
