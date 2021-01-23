using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaptorRentals.Data.Migrations
{
    public partial class AddIdentityAndRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeName = table.Column<string>(nullable: false),
                    HomeAddress = table.Column<string>(nullable: true),
                    PurchasePrice = table.Column<double>(nullable: false),
                    LoanAmount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    LoanLength = table.Column<int>(nullable: false),
                    DownPayment = table.Column<double>(nullable: false),
                    ClosingCost = table.Column<double>(nullable: false),
                    EstimatedRepairCost = table.Column<double>(nullable: false),
                    ProjectCost = table.Column<double>(nullable: false),
                    InitialCapitalNeeded = table.Column<double>(nullable: false),
                    MortgagePayment = table.Column<double>(nullable: false),
                    Taxes = table.Column<double>(nullable: false),
                    Insurance = table.Column<double>(nullable: false),
                    HOA = table.Column<double>(nullable: false),
                    Maintenance = table.Column<double>(nullable: false),
                    Vacancy = table.Column<double>(nullable: false),
                    CapitalExpenditure = table.Column<double>(nullable: false),
                    PropertyManagement = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Income = table.Column<double>(nullable: false),
                    Expenses = table.Column<double>(nullable: false),
                    CashFlow = table.Column<double>(nullable: false),
                    CashOnCash = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
