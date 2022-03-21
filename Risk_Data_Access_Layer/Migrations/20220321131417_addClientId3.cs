using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addClientId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
