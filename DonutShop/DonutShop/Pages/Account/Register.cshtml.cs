using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DonutShop.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public UserRegistration UserInput { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }

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
                    return RedirectToAction("Index", "Home");
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
            public Donut FavoriteDonut { get; set; }
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