using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addcustomerrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "Call",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Call_customerId",
                table: "Call",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call",
                column: "customerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call");

            migrationBuilder.DropIndex(
                name: "IX_Call_customerId",
                table: "Call");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Call");
        }
    }
}
