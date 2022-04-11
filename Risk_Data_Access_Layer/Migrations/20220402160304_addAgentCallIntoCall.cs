using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addAgentCallIntoCall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerServiceId",
                table: "Call",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Call_CustomerServiceId",
                table: "Call",
                column: "CustomerServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call",
                column: "CustomerServiceId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call");

            migrationBuilder.DropIndex(
                name: "IX_Call_CustomerServiceId",
                table: "Call");

            migrationBuilder.DropColumn(
                name: "CustomerServiceId",
                table: "Call");
        }
    }
}
