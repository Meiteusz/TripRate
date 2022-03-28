using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class ChangeTripClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "ReviewTrips");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_Localization",
                table: "ReviewTrips",
                newName: "IX_ReviewTrips_Localization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewTrips",
                table: "ReviewTrips",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewTrips",
                table: "ReviewTrips");

            migrationBuilder.RenameTable(
                name: "ReviewTrips",
                newName: "Trips");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewTrips_Localization",
                table: "Trips",
                newName: "IX_Trips_Localization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");
        }
    }
}
