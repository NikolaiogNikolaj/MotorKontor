using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerID_Username_Email",
                table: "Customer",
                columns: new[] { "CustomerID", "Username", "Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerID_Username_Email",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer",
                column: "CustomerID");
        }
    }
}
