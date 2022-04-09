using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class RemoveUserIdUniqueOnReviewTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips",
                column: "UserId",
                unique: true);
        }
    }
}
