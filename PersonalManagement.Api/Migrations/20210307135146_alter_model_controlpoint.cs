using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalManagement.Api.Migrations
{
    public partial class alter_model_controlpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraTrabalho",
                table: "ControlPoints",
                newName: "HourInputTwo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ControlPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HourExitOne",
                table: "ControlPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HourExitTwo",
                table: "ControlPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HourInputOne",
                table: "ControlPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "ControlPoints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ControlPoints");

            migrationBuilder.DropColumn(
                name: "HourExitOne",
                table: "ControlPoints");

            migrationBuilder.DropColumn(
                name: "HourExitTwo",
                table: "ControlPoints");

            migrationBuilder.DropColumn(
                name: "HourInputOne",
                table: "ControlPoints");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "ControlPoints");

            migrationBuilder.RenameColumn(
                name: "HourInputTwo",
                table: "ControlPoints",
                newName: "HoraTrabalho");
        }
    }
}
