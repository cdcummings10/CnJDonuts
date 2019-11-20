using DonutShop.Data;
using DonutShop.Models;
using DonutShop.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        #region Getter Setter Tests
        [Fact]
        public void GetterSetterTestsForDonut()
        {
            Donut donut = new Donut()
            {
                ID = 1,
                Name = "Hoopty",
                Description = "Boopty",
                SKU = "123",
                Price = 2.5m,
                ImageUrl = "Swoopty",
                Boozey = false,
                CreamFilled = true
            };

            Assert.Equal(1, donut.ID);
            Assert.Equal("Hoopty", donut.Name);
            Assert.Equal("Boopty", donut.Description);
            Assert.Equal("123", donut.SKU);
            Assert.Equal(2.5m, donut.Price);
            Assert.Equal("Swoopty", donut.ImageUrl);
            Assert.False(donut.Boozey);
            Assert.True(donut.CreamFilled);
        }
        [Fact]
        public void GetterSetterTestForUser()
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = "Goopty",
                LastName = "Shoopty",
                FavoriteDonut = FaveDonut.Confetti,
                UserName = "hello",
                Email = "shup@shup.com"
            };

            Assert.Equal("Goopty", user.FirstName);
            Assert.Equal("Shoopty", user.LastName);
            Assert.Equal(FaveDonut.Confetti, user.FavoriteDonut);
            Assert.Equal("hello", user.UserName);
            Assert.Equal("shup@shup.com", user.Email);
        }
        #endregion
        #region DB testing
        [Fact]
        public async void TestDonutServiceCreateMethod()
        {
            DbContextOptions<InventoryDbContext> options = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase("TestDonutServiceCreateMethod")
            .Options;

            using (InventoryDbContext context = new InventoryDbContext(options))
            {
                DonutService service = new DonutService(context);
                Donut donut = new Donut()
                {
                    ID = 3,
                    Name = "Joopty",
                    Description = "Loopty",
                    SKU = "456",
                    Price = 5.5m,
                    ImageUrl = "Koopty",
                    Boozey = true,
                    CreamFilled = true
                };

                await service.Create(donut);

                Donut result = await context.Donuts.FirstOrDefaultAsync(x => x.ID == donut.ID);

                Assert.Equal(result.ID, donut.ID);
            }
        }
        #endregion
    }
}
