using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer");
        }
    }
}
