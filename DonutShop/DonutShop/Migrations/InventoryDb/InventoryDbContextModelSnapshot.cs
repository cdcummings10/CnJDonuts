﻿// <auto-generated />
using DonutShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DonutShop.Migrations.InventoryDb
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DonutShop.Models.Donut", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Boozey")
                        .HasColumnType("bit");

                    b.Property<bool>("CreamFilled")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Donuts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Boozey = true,
                            CreamFilled = false,
                            Description = "Cinnamon with a twist! A cinnamon twist donut made with a fiery cinnamon whiskey.",
                            ImageUrl = "https://i.pinimg.com/originals/bd/bf/f5/bdbff556126cd42ff4a05d37cf3d4ead.jpg",
                            Name = "Cinnamon Whiskey Twist",
                            Price = 5.5m,
                            SKU = "111"
                        },
                        new
                        {
                            ID = 2,
                            Boozey = true,
                            CreamFilled = true,
                            Description = "A maple bar, but better. It's cream filled. But better still! The cream is a rum cream for the best kick in a donut!",
                            ImageUrl = "https://i2.wp.com/butterwithasideofbread.com/wp-content/uploads/2015/06/15MinuteMapleBars3.jpg?resize=632%2C852&ssl=1",
                            Name = "Cream Filled Rum Maple Bar",
                            Price = 5.5m,
                            SKU = "222"
                        },
                        new
                        {
                            ID = 3,
                            Boozey = false,
                            CreamFilled = false,
                            Description = "Your tried and true, lovely maple bar. No other description required.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/ce/FullLongJohn.jpg",
                            Name = "Maple Bar",
                            Price = 2.5m,
                            SKU = "333"
                        },
                        new
                        {
                            ID = 4,
                            Boozey = false,
                            CreamFilled = false,
                            Description = "Old fashioned donut covered in glaze and made ready to eat! Oldy but goody!",
                            ImageUrl = "http://jensfavoritecookies.com/wp-content/uploads/2016/10/old-fashioned-donuts-12-300x300.jpg",
                            Name = "Old Fashioned",
                            Price = 2.5m,
                            SKU = "444"
                        },
                        new
                        {
                            ID = 5,
                            Boozey = false,
                            CreamFilled = true,
                            Description = "A chocolate covered donut full of chocolate cream. Double chocolate for the chocolate lovers.",
                            ImageUrl = "https://www.halfbakedharvest.com/wp-content/uploads/2013/02/Chocolate-Irish-Cream-Filled-Dounuts-12.jpg",
                            Name = "Chocolate Cream Filled",
                            Price = 3m,
                            SKU = "555"
                        },
                        new
                        {
                            ID = 6,
                            Boozey = false,
                            CreamFilled = false,
                            Description = "A classic donut covered in chocolate frosting. It's amazing, simple and delicious.",
                            ImageUrl = "https://assets.epicurious.com/photos/57978bbc3a12dd9d5602400a/2:1/w_1260%2Ch_630/chocolate-glaze.jpg",
                            Name = "Chocolate Frosting",
                            Price = 2.5m,
                            SKU = "666"
                        },
                        new
                        {
                            ID = 7,
                            Boozey = false,
                            CreamFilled = false,
                            Description = "A donut twist covered in delicious cinnamon sugar. Delicious!",
                            ImageUrl = "https://miro.medium.com/max/4536/1*ZhdMfGD7bWxjphgxmsjdkg.jpeg",
                            Name = "Cinnamon Twist",
                            Price = 2.5m,
                            SKU = "777"
                        },
                        new
                        {
                            ID = 8,
                            Boozey = false,
                            CreamFilled = true,
                            Description = "Your classic maple bar, but why not add more? Cream filled and wonderful.",
                            ImageUrl = "https://thefoodcharlatan.com/wp-content/uploads/2012/04/IMG_3167-e1386614602801.jpg",
                            Name = "Cream Filled Maple Bar",
                            Price = 3m,
                            SKU = "888"
                        },
                        new
                        {
                            ID = 9,
                            Boozey = false,
                            CreamFilled = false,
                            Description = "A confetti cake style donut covered in frosting and sprinkles! Very festive and very tasty.",
                            ImageUrl = "https://melssweetlife.files.wordpress.com/2012/05/donuts.jpg",
                            Name = "Confetti",
                            Price = 2.5m,
                            SKU = "999"
                        },
                        new
                        {
                            ID = 10,
                            Boozey = true,
                            CreamFilled = true,
                            Description = "Our confetti donut but filled with a vodka cream. Celebrate your favorite event!",
                            ImageUrl = "https://cdn.evermine.com/blog/wp-content/uploads/2015/03/Funfetti-Donuts-15.jpg",
                            Name = "Vodka Cream Filled Confetti",
                            Price = 5.5m,
                            SKU = "101"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
