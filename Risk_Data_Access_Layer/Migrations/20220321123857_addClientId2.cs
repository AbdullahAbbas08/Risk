using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addClientId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ClientId",
                schema: "dbo",
                table: "Customers",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "dbo",
                table: "Customers");
        }
    }
}
