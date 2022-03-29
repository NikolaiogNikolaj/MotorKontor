using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class storedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure1 = @"CREATE PROCEDURE spGetVehiclesByFuelType
                @FuelType int
                as
                Begin
	                SELECT * FROM Vehicle
	                WHERE FuelType = @FuelType
                END";


            migrationBuilder.CreateIndex(
                name: "IX_Customer",
                table: "Customer",
                column: "CustomerID");


            migrationBuilder.Sql(procedure1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure1 = @"Drop PROCEDURE spGetVehiclesByFuelType";

            migrationBuilder.Sql(procedure1);

        }
    }
}
