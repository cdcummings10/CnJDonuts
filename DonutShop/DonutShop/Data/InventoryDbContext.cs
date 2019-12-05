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
            builder.Entity<OrderItem>().HasKey(item => new { item.OrderID, item.DonutID });

            builder.Entity<Donut>().HasData(
                new Donut
                {
                    ID = 1,
                    Name = "Cinnamon Whiskey Twist",
                    Description = "Cinnamon with a twist! A cinnamon twist donut made with a fiery cinnamon whiskey.",
                    SKU = "111",
                    Price = 5.5m,
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/CinnamonWhiskeyTwist.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/CreamFilledRumMapleBar.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/MapleBar.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/OldFashioned.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/ChocolateCreamFilled.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/ChocolateFrosting.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/CinnamonTwist.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/CreamFilledMapleBar.png",
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
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/Confetti.png",
                    Boozey = false,
                    CreamFilled = false
                },
                new Donut
                {
                    ID = 10,
                    Name = "Vodka Cream Filled Confetti",
                    Description = "Our confetti donut but filled with a vodka cream. Celebrate your favorite event!",
                    SKU = "101",
                    Price = 5.5m,
                    ImageUrl = "https://cnjdonuts.blob.core.windows.net/products/VodkaCreamFilledConfetti.png",
                    Boozey = true,
                    CreamFilled = true
                }
                );
        }
        public DbSet<Donut> Donuts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
