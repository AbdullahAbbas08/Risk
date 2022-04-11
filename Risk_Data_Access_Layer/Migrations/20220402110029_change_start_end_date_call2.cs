using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class change_start_end_date_call2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Call");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Call");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndCall",
                table: "Call",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartCall",
                table: "Call",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndCall",
                table: "Call");

            migrationBuilder.DropColumn(
                name: "StartCall",
                table: "Call");

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "Call",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Call",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
