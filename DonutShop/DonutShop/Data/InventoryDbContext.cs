using DonutShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Seeds data into the database.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Donut>().HasData(
                new Donut
                {
                    ID = 1,
                    Name = "Cinnamon Whiskey Twist",
                    Description = "Cinnamon with a twist! A cinnamon twist donut made with a fiery cinnamon whiskey.",
                    SKU = "111",
                    Price = 5.5m,
                    ImageUrl = "https://i.pinimg.com/originals/bd/bf/f5/bdbff556126cd42ff4a05d37cf3d4ead.jpg",
                    Boozey = true,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 2,
                    Name = "Cream Filled Rum Maple Bar",
                    Description = "A maple bar, but better. It's cream filled. But better still! The cream is a rum cream for the best kick in a donut!",
                    SKU = "222",
                    Price = 5.5m,
                    ImageUrl = "https://i2.wp.com/butterwithasideofbread.com/wp-content/uploads/2015/06/15MinuteMapleBars3.jpg?resize=632%2C852&ssl=1",
                    Boozey = true,
                    CreamFilled = true
                },
                new Donut
                {
                    ID = 3,
                    Name = "Maple Bar",
                    Description = "Your tried and true, lovely maple bar. No other description required.",
                    SKU = "333",
                    Price = 2.5m,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/ce/FullLongJohn.jpg",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 4,
                    Name = "Old Fashioned",
                    Description = "Old fashioned donut covered in glaze and made ready to eat! Oldy but goody!",
                    SKU = "444",
                    Price = 2.5m,
                    ImageUrl = "http://jensfavoritecookies.com/wp-content/uploads/2016/10/old-fashioned-donuts-12-300x300.jpg",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 5,
                    Name = "Chocolate Cream Filled",
                    Description = "A chocolate covered donut full of chocolate cream. Double chocolate for the chocolate lovers.",
                    SKU = "555",
                    Price = 3m,
                    ImageUrl = "https://www.halfbakedharvest.com/wp-content/uploads/2013/02/Chocolate-Irish-Cream-Filled-Dounuts-12.jpg",
                    Boozey = false,
                    CreamFilled = true
                },
                new Donut
                {
                    ID = 6,
                    Name = "Chocolate Frosting",
                    Description = "A classic donut covered in chocolate frosting. It's amazing, simple and delicious.",
                    SKU = "666",
                    Price = 2.5m,
                    ImageUrl = "https://assets.epicurious.com/photos/57978bbc3a12dd9d5602400a/2:1/w_1260%2Ch_630/chocolate-glaze.jpg",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 7,
                    Name = "Cinnamon Twist",
                    Description = "A donut twist covered in delicious cinnamon sugar. Delicious!",
                    SKU = "777",
                    Price = 2.5m,
                    ImageUrl = "https://miro.medium.com/max/4536/1*ZhdMfGD7bWxjphgxmsjdkg.jpeg",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 8,
                    Name = "Cream Filled Maple Bar",
                    Description = "Your classic maple bar, but why not add more? Cream filled and wonderful.",
                    SKU = "888",
                    Price = 3m,
                    ImageUrl = "https://thefoodcharlatan.com/wp-content/uploads/2012/04/IMG_3167-e1386614602801.jpg",
                    Boozey = false,
                    CreamFilled = true
                },
                new Donut
                {
                    ID = 9,
                    Name = "Confetti",
                    Description = "A confetti cake style donut covered in frosting and sprinkles! Very festive and very tasty.",
                    SKU = "999",
                    Price = 2.5m,
                    ImageUrl = "https://melssweetlife.files.wordpress.com/2012/05/donuts.jpg",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 1,
                    Name = "Vodka Cream Filled Confetti",
                    Description = "Our confetti donut but filled with a vodka cream. Celebrate your favorite event!",
                    SKU = "101",
                    Price = 5.5m,
                    ImageUrl = "https://cdn.evermine.com/blog/wp-content/uploads/2015/03/Funfetti-Donuts-15.jpg",
                    Boozey = true,
                    CreamFilled = true
                }
                );
        }
        public DbSet<Donut> Donuts { get; set; }
    }
}
