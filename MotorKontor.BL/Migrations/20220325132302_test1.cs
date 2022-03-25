using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerID",
                table: "Address",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerID",
                table: "Address",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomerID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Address");
        }
    }
}
