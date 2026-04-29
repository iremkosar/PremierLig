using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLig.DataAccessLayer.Migrations
{
    public partial class AddTeamIdToMatchDetailAndStatsFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "MatchDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeCorners",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayCorners",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeFouls",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayFouls",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeOffsides",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayOffsides",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeYellowCards",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayYellowCards",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeRedCards",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayRedCards",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeShotsOnTarget",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayShotsOnTarget",
                table: "MatchStatistics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "TeamId", table: "MatchDetails");
            migrationBuilder.DropColumn(name: "HomeCorners", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayCorners", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "HomeFouls", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayFouls", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "HomeOffsides", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayOffsides", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "HomeYellowCards", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayYellowCards", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "HomeRedCards", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayRedCards", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "HomeShotsOnTarget", table: "MatchStatistics");
            migrationBuilder.DropColumn(name: "AwayShotsOnTarget", table: "MatchStatistics");
        }
    }
}
