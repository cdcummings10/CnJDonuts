using DonutShop.Models;
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
                ImageUrl = "Swoopty",
                Boozey = false,
                CreamFilled = true
            };

            Assert.Equal(1, donut.ID);
            Assert.Equal("Hoopty", donut.Name);
            Assert.Equal("Boopty", donut.Description);
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
    }
}
