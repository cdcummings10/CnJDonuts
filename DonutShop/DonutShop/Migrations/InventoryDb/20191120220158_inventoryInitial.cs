using Microsoft.EntityFrameworkCore.Migrations;

namespace DonutShop.Migrations.InventoryDb
{
    public partial class inventoryInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donuts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Boozey = table.Column<bool>(nullable: false),
                    CreamFilled = table.Column<bool>(nullable: false),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donuts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Donuts",
                columns: new[] { "ID", "Boozey", "CreamFilled", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, true, false, "Cinnamon with a twist! A cinnamon twist donut made with a fiery cinnamon whiskey.", "https://i.pinimg.com/originals/bd/bf/f5/bdbff556126cd42ff4a05d37cf3d4ead.jpg", "Cinnamon Whiskey Twist", 5.5m, "111" },
                    { 2, true, true, "A maple bar, but better. It's cream filled. But better still! The cream is a rum cream for the best kick in a donut!", "https://i2.wp.com/butterwithasideofbread.com/wp-content/uploads/2015/06/15MinuteMapleBars3.jpg?resize=632%2C852&ssl=1", "Cream Filled Rum Maple Bar", 5.5m, "222" },
                    { 3, false, false, "Your tried and true, lovely maple bar. No other description required.", "https://upload.wikimedia.org/wikipedia/en/c/ce/FullLongJohn.jpg", "Maple Bar", 2.5m, "333" },
                    { 4, false, false, "Old fashioned donut covered in glaze and made ready to eat! Oldy but goody!", "http://jensfavoritecookies.com/wp-content/uploads/2016/10/old-fashioned-donuts-12-300x300.jpg", "Old Fashioned", 2.5m, "444" },
                    { 5, false, true, "A chocolate covered donut full of chocolate cream. Double chocolate for the chocolate lovers.", "https://www.halfbakedharvest.com/wp-content/uploads/2013/02/Chocolate-Irish-Cream-Filled-Dounuts-12.jpg", "Chocolate Cream Filled", 3m, "555" },
                    { 6, false, false, "A classic donut covered in chocolate frosting. It's amazing, simple and delicious.", "https://assets.epicurious.com/photos/57978bbc3a12dd9d5602400a/2:1/w_1260%2Ch_630/chocolate-glaze.jpg", "Chocolate Frosting", 2.5m, "666" },
                    { 7, false, false, "A donut twist covered in delicious cinnamon sugar. Delicious!", "https://miro.medium.com/max/4536/1*ZhdMfGD7bWxjphgxmsjdkg.jpeg", "Cinnamon Twist", 2.5m, "777" },
                    { 8, false, true, "Your classic maple bar, but why not add more? Cream filled and wonderful.", "https://thefoodcharlatan.com/wp-content/uploads/2012/04/IMG_3167-e1386614602801.jpg", "Cream Filled Maple Bar", 3m, "888" },
                    { 9, false, false, "A confetti cake style donut covered in frosting and sprinkles! Very festive and very tasty.", "https://melssweetlife.files.wordpress.com/2012/05/donuts.jpg", "Confetti", 2.5m, "999" },
                    { 10, true, true, "Our confetti donut but filled with a vodka cream. Celebrate your favorite event!", "https://cdn.evermine.com/blog/wp-content/uploads/2015/03/Funfetti-Donuts-15.jpg", "Vodka Cream Filled Confetti", 5.5m, "101" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donuts");
        }
    }
}
