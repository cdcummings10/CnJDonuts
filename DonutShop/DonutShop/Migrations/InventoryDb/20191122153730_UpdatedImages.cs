using Microsoft.EntityFrameworkCore.Migrations;

namespace DonutShop.Migrations.InventoryDb
{
    public partial class UpdatedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "/assets/images/CinnamonWhiskeyTwist.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "/assets/images/CreamFilledRumMapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "/assets/images/MapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "/assets/images/OldFashioned.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "/assets/images/ChocolateCreamFilled.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "/assets/images/ChocolateFrosting.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: "/assets/images/CinnamonTwist.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageUrl",
                value: "/assets/images/CreamFilledMapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageUrl",
                value: "/assets/images/Confetti.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageUrl",
                value: "/assets/images/VodkaCreamFilledConfetti.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/assets/images/CinnamonWhiskeyTwist.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/assets/images/CreamFilledRumMapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/assets/images/MapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/assets/images/OldFashioned.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/assets/images/ChocolateCreamFilled.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "~/assets/images/ChocolateFrosting.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: "~/assets/images/CinnamonTwist.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageUrl",
                value: "~/assets/images/CreamFilledMapleBar.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageUrl",
                value: "~/assets/images/Confetti.png");

            migrationBuilder.UpdateData(
                table: "Donuts",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageUrl",
                value: "~/assets/images/VodkaCreamFilledConfetti.png");
        }
    }
}
