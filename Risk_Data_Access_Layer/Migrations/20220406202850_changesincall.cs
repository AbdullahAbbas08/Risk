using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class changesincall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Clients_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ClientId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Call",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Call_ClientId",
                table: "Call",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call");

            migrationBuilder.DropIndex(
                name: "IX_Call_ClientId",
                table: "Call");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Call");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
