using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class UserIdUniqueOnReviewTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_Localization",
                table: "ReviewTrips");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_Localization",
                table: "ReviewTrips",
                column: "Localization",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips",
                column: "UserId");
        }
    }
}
