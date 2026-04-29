using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLig.DataAccessLayer.Migrations
{
    public partial class AddLeagueSeasonStadium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stadium",
                table: "Fixtures",
                newName: "Referee");

            migrationBuilder.AddColumn<int>(
                name: "HomeStadiumId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<int>(
                name: "Attendance",
                table: "Fixtures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Fixtures",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<int>(
                name: "StadiumId",
                table: "Fixtures",
                type: "int",
                nullable: true,
                defaultValue: null);

           

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeStadiumId",
                table: "Teams",
                column: "HomeStadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_SeasonId",
                table: "Fixtures",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_StadiumId",
                table: "Fixtures",
                column: "StadiumId");

           

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_LeagueId",
                table: "Seasons",
                column: "LeagueId");

          

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Stadiums_StadiumId",
                table: "Fixtures",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Restrict);

           

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_HomeStadiumId",
                table: "Teams",
                column: "HomeStadiumId",
                principalTable: "Stadiums",
                principalColumn: "StadiumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Seasons_SeasonId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Stadiums_StadiumId",
                table: "Fixtures");

          
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_AwayTeamId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_HomeTeamId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_HomeStadiumId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HomeStadiumId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_SeasonId",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_StadiumId",
                table: "Fixtures");

          

            migrationBuilder.DropColumn(
                name: "HomeStadiumId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Fixtures");

          
            migrationBuilder.RenameColumn(
                name: "Referee",
                table: "Fixtures",
                newName: "Stadium");
        }
    }
}
