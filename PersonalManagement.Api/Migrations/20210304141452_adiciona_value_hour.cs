using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalManagement.Api.Migrations
{
    public partial class adiciona_value_hour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HourValue",
                table: "ControlPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourValue",
                table: "ControlPoints");
        }
    }
}
