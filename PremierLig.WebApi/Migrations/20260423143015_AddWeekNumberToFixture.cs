using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLig.WebApi.Migrations
{
    public partial class AddWeekNumberToFixture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "Fixtures");
        }
    }
}
