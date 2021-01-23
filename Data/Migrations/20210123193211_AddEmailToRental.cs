using Microsoft.EntityFrameworkCore.Migrations;

namespace RaptorRentals.Data.Migrations
{
    public partial class AddEmailToRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccount",
                table: "Rentals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAccount",
                table: "Rentals");
        }
    }
}
