using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorKontor.BL.Migrations
{
    public partial class storedProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetVehiclesByFuelType
                @FuelType int
                as
                Begin
	                SELECT * FROM Vehicle
	                WHERE FuelType = @FuelType
                END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop PROCEDURE spGetVehiclesByFuelType";

            migrationBuilder.Sql(procedure);
        }
    }
}
