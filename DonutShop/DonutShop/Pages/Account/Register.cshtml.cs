﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DonutShop.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICart _cartManager;
        private IEmailSender _emailSender;

        public IConfiguration Configuration { get; private set; }


        [BindProperty]
        public UserRegistration UserInput { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, ICart cartManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartManager = cartManager;
            Configuration = configuration;
            _emailSender = emailSender;
        }
        public void OnGet()
        {

        }
        /// <summary>
        /// Takes the form populated property newUser and creates a new ApplicationUser. The user is added to the database
        /// and is signed in. Claims are also added.
        /// </summary>
        /// <returns>If registration is successful, redirects to home index. If not, adds errors to page.</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    UserName = UserInput.Email,
                    Email = UserInput.Email,
                    FirstName = UserInput.FirstName,
                    LastName = UserInput.LastName,
                    BirthDate = UserInput.BirthDate,
                    FavoriteDonut = UserInput.FavoriteDonut
                };
                var result = await _userManager.CreateAsync(newUser, UserInput.Password);
                if (result.Succeeded)
                {
                    Claim name = new Claim("FirstName", newUser.FirstName);
                    Claim birthDate = new Claim(
                        ClaimTypes.DateOfBirth,
                        new DateTime(newUser.BirthDate.Year, newUser.BirthDate.Month, newUser.BirthDate.Day).ToString("u"), 
                        ClaimValueTypes.DateTime);
                    Claim email = new Claim(ClaimTypes.Email, newUser.Email, ClaimValueTypes.Email);
                    List<Claim> claims = new List<Claim> { name, birthDate, email };

                    if(UserInput.Email.Contains(Configuration["AdminEmail"]))
                    {
                        await _userManager.AddToRoleAsync(newUser, ApplicationRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(newUser, ApplicationRoles.Member);

                    await _userManager.AddClaimsAsync(newUser, claims);

                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    // generate new cart for the user.
                    Cart cart = new Cart() { UserEmail = UserInput.Email };
                    await _cartManager.GenerateCart(cart);

                    // send welcome email.
                    string subject = "Welcome to C&J Donuts!";
                    string message = $"Thank you for joining C&J Donuts, {newUser.FirstName}!";
                    await _emailSender.SendEmailAsync(newUser.Email, subject, message);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }


        public class UserRegistration
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
            [Display(Name = "Favorite Donut")]
            public FaveDonut FavoriteDonut { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [StringLength(50, ErrorMessage = "Your {0} must be between {2} and {1} characters.", MinimumLength = 6)]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and confirmation do not match.")]
            public string ConfirmPassword { get; set; }

        }
    }
}