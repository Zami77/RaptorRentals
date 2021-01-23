using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace RaptorRentals.Data
{
    public class RentalInvestment
    {
        public RentalInvestment()
        {
            this.LoanLength = 30;
        }

        public int Id { get; set; }

        [Required]
        public string HomeName { get; set; }

        public string HomeAddress { get; set; }

        [Required]
        public double PurchasePrice { get; set; }

        public double LoanAmount { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Interest invalid, " +
            "should be between 0-100.")]
        public double InterestRate { get; set; }

        [Required]
        public int LoanLength { get; set; }

        public double DownPayment { get; set; } //Percentage

        public double ClosingCost { get; set; }

        public double EstimatedRepairCost { get; set; }

        public double ProjectCost { get; set; }

        public double InitialCapitalNeeded { get; set; }
        
        public double MortgagePayment { get; set; }

        public double Taxes { get; set; }

        public double Insurance { get; set; }

        public double HOA { get; set; }

        public double Maintenance { get; set; } //Percentage

        public double Vacancy { get; set; } //Percentage

        public double CapitalExpenditure { get; set; } //Percentage

        public double PropertyManagement { get; set; } //Percentage

        public DateTime Date { get; set; } //May not be required

        public double Income { get; set; }

        public double Expenses { get; set; }

        public double CashFlow { get; set; }

        public double CashOnCash { get; set; }

        public string UserAccount { get; set; }

        public void SolveMortgage()
        {
            var downPayment = this.DownPayment / 100 * this.PurchasePrice;
            this.ProjectCost = this.PurchasePrice + this.EstimatedRepairCost +
                this.ClosingCost;
            this.LoanAmount = this.PurchasePrice - downPayment;
            this.InitialCapitalNeeded = downPayment + this.ClosingCost +
                this.EstimatedRepairCost;
            //Edge case if 0% interest rate
            if (this.InterestRate == 0)
            {
                this.MortgagePayment = this.LoanAmount / this.LoanLength / 12;
                return;
            }
            /*
                Mortgage = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]

                P = principal loan amount

                i = monthly interest rate

                n = number of months required to repay the loan 
             */

            int numMonths = this.LoanLength * 12;
            var monthlyIntRate = this.InterestRate / 100 / 12;

            //formula above implemented
            this.MortgagePayment = this.LoanAmount
                * (monthlyIntRate * Math.Pow(1 + monthlyIntRate, numMonths))
                / (Math.Pow(1 + monthlyIntRate, numMonths) - 1);

        }

        public void SolveCashFlow()
        {
            double maintenance = this.Income * (this.Maintenance / 100);
            double vacancy = this.Income * (this.Vacancy / 100);
            double capEx = this.Income * (this.CapitalExpenditure / 100);
            double propMgmt = this.Income * (this.PropertyManagement / 100);

            this.Expenses = maintenance + vacancy + capEx + propMgmt
                + this.MortgagePayment + this.Taxes + this.Insurance + this.HOA;

            this.CashFlow = this.Income - this.Expenses;
        }

        public void SolveCashOnCash()
        {
            if(this.InitialCapitalNeeded == 0)
            {
                this.CashOnCash = 100;//perfect cash flow
                return;
            }
            this.CashOnCash = (this.CashFlow * 12 / this.InitialCapitalNeeded)
                * 100;
        }

        public string DisplayMoney(double num)
        {
            var roundedNum = Math.Round(num, 2, MidpointRounding.AwayFromZero);
            return String.Format("{0:n}", roundedNum);
        }

        public void GenerateExcel(IJSRuntime iJSRuntime)
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add(this.HomeName);

                //Fill out sheet
                //TODO: Find a cleaner way to do this

                workSheet.Cells[1, 1].Value = "Property Information";
                workSheet.Cells[1, 1].Style.Font.Size = 16;
                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 1].Style.Border.Top.Style =
                    OfficeOpenXml.Style.ExcelBorderStyle.Hair;
                workSheet.Cells[1, 1].AutoFitColumns();

                int row = 2;
                populateCell(workSheet, "Home Name", this.HomeName, row++);
                populateCell(workSheet, "Home Address", this.HomeAddress, row++);
                populateCell(workSheet, "Purchase Price",
                    "$" + Convert.ToDouble(DisplayMoney(this.PurchasePrice)), row++);
                populateCell(workSheet, "Down Payment",
                    "$" + DisplayMoney(this.DownPayment / 100 * this.PurchasePrice), row++);
                populateCell(workSheet, "Closing Costs",
                    "$" + DisplayMoney(this.ClosingCost), row++);
                populateCell(workSheet, "Estimate Repair Cost",
                    "$" + DisplayMoney(this.EstimatedRepairCost), row++);
                populateCell(workSheet, "Interest Rate",
                    "%" + DisplayMoney(this.InterestRate), row++);
                populateCell(workSheet, "Loan Length",
                    this.LoanLength.ToString(), row++);



                fileContents = package.GetAsByteArray();

            }

            iJSRuntime.InvokeAsync<RentalInvestment>(
                "saveAsFile",
                this.HomeName + ".xlsx",
                Convert.ToBase64String(fileContents)
                );
        }

        public void populateCell(ExcelWorksheet workSheet, string field,
            object val, int row)
        {
            workSheet.Cells[row, 1].Value = field;
            workSheet.Cells[row, 1].Style.Font.Bold = true;
            workSheet.Cells[row, 1].Style.Font.Size = 12;
            workSheet.Cells[row, 1].AutoFitColumns();

            workSheet.Cells[row, 2].Value = val;
            workSheet.Cells[row, 2].Style.Font.Size = 12;
            workSheet.Cells[row, 2].AutoFitColumns();
        }
    }
}