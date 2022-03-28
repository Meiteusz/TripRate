using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class UserIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReviewTrips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTrips_Users_UserId",
                table: "ReviewTrips",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTrips_Users_UserId",
                table: "ReviewTrips");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTrips_UserId",
                table: "ReviewTrips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReviewTrips");
        }
    }
}
