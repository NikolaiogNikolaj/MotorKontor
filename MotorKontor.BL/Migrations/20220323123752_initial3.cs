using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_UserAddressAddressID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserAddressAddressID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserAddressAddressID",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAddressAddressID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserAddressAddressID",
                table: "Customer",
                column: "UserAddressAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_UserAddressAddressID",
                table: "Customer",
                column: "UserAddressAddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
