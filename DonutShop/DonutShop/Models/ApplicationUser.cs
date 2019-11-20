using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Donut FavoriteDonut { get; set; }

    }
    public enum Donut
    {
        [Display(Name ="Cinnamon Whiskey Twist")]
        CinnamonWhiskeyTwist = 1,
        [Display(Name = "Cream Filled Rum Maple Bar")]
        CreamFilledRumMapleBar,
        [Display(Name = "Maple Bar")]
        MapleBar,
        [Display(Name ="Old Fashioned")]
        OldFashioned,
        [Display(Name = "Chocolate Cream Filled")]
        ChocolateCreamFilled,
        [Display(Name = "Chocolate Frosting")]
        ChocolateFrosting,
        [Display(Name ="Cinnamon Twist")]
        CinnamonTwist,
        [Display(Name = "Cream Filled Maple Bar")]
        CreamFilledMapleBar,
        Confetti,
        [Display(Name = "Vodka Cream Filled Confetti")]
        VodkaCreamFilledConfetti,
    }
}
