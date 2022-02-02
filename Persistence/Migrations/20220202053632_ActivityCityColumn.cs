using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ActivityCityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyPropCityerty",
                table: "Activities",
                newName: "Venue");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Activities",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Venue",
                table: "Activities",
                newName: "MyPropCityerty");
        }
    }
}
