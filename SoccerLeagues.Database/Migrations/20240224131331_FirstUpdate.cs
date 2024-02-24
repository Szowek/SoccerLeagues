using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerLeagues.Database.Migrations
{
    /// <inheritdoc />
    public partial class FirstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePhase_Leagues_LeagueId",
                table: "LeaguePhase");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_LeaguePhase_LeaguePhaseId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_LeaguePhase_LeaguePhaseId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaguePhase",
                table: "LeaguePhase");

            migrationBuilder.RenameTable(
                name: "LeaguePhase",
                newName: "LeaguePhases");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePhase_LeagueId",
                table: "LeaguePhases",
                newName: "IX_LeaguePhases_LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaguePhases",
                table: "LeaguePhases",
                column: "LeaguePhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePhases_Leagues_LeagueId",
                table: "LeaguePhases",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_LeaguePhases_LeaguePhaseId",
                table: "Matches",
                column: "LeaguePhaseId",
                principalTable: "LeaguePhases",
                principalColumn: "LeaguePhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_LeaguePhases_LeaguePhaseId",
                table: "Teams",
                column: "LeaguePhaseId",
                principalTable: "LeaguePhases",
                principalColumn: "LeaguePhaseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePhases_Leagues_LeagueId",
                table: "LeaguePhases");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_LeaguePhases_LeaguePhaseId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_LeaguePhases_LeaguePhaseId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaguePhases",
                table: "LeaguePhases");

            migrationBuilder.RenameTable(
                name: "LeaguePhases",
                newName: "LeaguePhase");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePhases_LeagueId",
                table: "LeaguePhase",
                newName: "IX_LeaguePhase_LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaguePhase",
                table: "LeaguePhase",
                column: "LeaguePhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePhase_Leagues_LeagueId",
                table: "LeaguePhase",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_LeaguePhase_LeaguePhaseId",
                table: "Matches",
                column: "LeaguePhaseId",
                principalTable: "LeaguePhase",
                principalColumn: "LeaguePhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_LeaguePhase_LeaguePhaseId",
                table: "Teams",
                column: "LeaguePhaseId",
                principalTable: "LeaguePhase",
                principalColumn: "LeaguePhaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
