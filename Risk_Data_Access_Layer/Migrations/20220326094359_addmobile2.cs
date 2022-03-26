using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addmobile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile2",
                schema: "dbo",
                table: "Customers",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "Customers",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile2",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "dbo",
                table: "Customers");
        }
    }
}
