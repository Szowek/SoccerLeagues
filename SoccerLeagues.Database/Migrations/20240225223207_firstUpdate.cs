using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerLeagues.Database.Migrations
{
    /// <inheritdoc />
    public partial class firstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTeams_UserId_TeamId",
                table: "FavoriteTeams",
                columns: new[] { "UserId", "TeamId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavoriteTeams_UserId_TeamId",
                table: "FavoriteTeams");
        }
    }
}
