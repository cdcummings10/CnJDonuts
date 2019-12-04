using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DonutShop.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public IConfiguration Configuration { get; }
        [BindProperty]
        public LoginInput UserInput { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            Configuration = configuration;
        }
        public void OnGet()
        {

        }
        /// <summary>
        /// Signs in a user using SignInManager object. Takes in Email, password and a boolean from a form to login.
        /// </summary>
        /// <returns>Returns index if login is successful, page with error if unsuccessful.</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserInput.Email, UserInput.Password, UserInput.RememberMe, false);

                if (result.Succeeded)
                {
                    if (UserInput.Email.Contains(Configuration["AdminEmail"]))
                    {
                        return Redirect("~/Admin/Portal");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login Attempt");
                    return Page();
                }
            }
            return Page();
        }


        public class LoginInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Stay logged in?")]
            public bool RememberMe { get; set; }
        }
    }
}