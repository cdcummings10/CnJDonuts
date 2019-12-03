using Microsoft.EntityFrameworkCore.Migrations;

namespace DonutShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(nullable: false),
                    DonutID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Donuts_DonutID",
                        column: x => x.DonutID,
                        principalTable: "Donuts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    DonutID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderID, x.DonutID });
                    table.ForeignKey(
                        name: "FK_OrderItems_Donuts_DonutID",
                        column: x => x.DonutID,
                        principalTable: "Donuts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Donuts",
                columns: new[] { "ID", "Boozey", "CreamFilled", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, true, false, "Cinnamon with a twist! A cinnamon twist donut made with a fiery cinnamon whiskey.", "/assets/images/CinnamonWhiskeyTwist.png", "Cinnamon Whiskey Twist", 5.5m, "111" },
                    { 2, true, true, "A maple bar, but better. It's cream filled. But better still! The cream is a rum cream for the best kick in a donut!", "/assets/images/CreamFilledRumMapleBar.png", "Cream Filled Rum Maple Bar", 5.5m, "222" },
                    { 3, false, false, "Your tried and true, lovely maple bar. No other description required.", "/assets/images/MapleBar.png", "Maple Bar", 2.5m, "333" },
                    { 4, false, false, "Old fashioned donut covered in glaze and made ready to eat! Oldy but goody!", "/assets/images/OldFashioned.png", "Old Fashioned", 2.5m, "444" },
                    { 5, false, true, "A chocolate covered donut full of chocolate cream. Double chocolate for the chocolate lovers.", "/assets/images/ChocolateCreamFilled.png", "Chocolate Cream Filled", 3m, "555" },
                    { 6, false, false, "A classic donut covered in chocolate frosting. It's amazing, simple and delicious.", "/assets/images/ChocolateFrosting.png", "Chocolate Frosting", 2.5m, "666" },
                    { 7, false, false, "A donut twist covered in delicious cinnamon sugar. Delicious!", "/assets/images/CinnamonTwist.png", "Cinnamon Twist", 2.5m, "777" },
                    { 8, false, true, "Your classic maple bar, but why not add more? Cream filled and wonderful.", "/assets/images/CreamFilledMapleBar.png", "Cream Filled Maple Bar", 3m, "888" },
                    { 9, false, false, "A confetti cake style donut covered in frosting and sprinkles! Very festive and very tasty.", "/assets/images/Confetti.png", "Confetti", 2.5m, "999" },
                    { 10, true, true, "Our confetti donut but filled with a vodka cream. Celebrate your favorite event!", "/assets/images/VodkaCreamFilledConfetti.png", "Vodka Cream Filled Confetti", 5.5m, "101" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_DonutID",
                table: "CartItems",
                column: "DonutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DonutID",
                table: "OrderItems",
                column: "DonutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Donuts");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
