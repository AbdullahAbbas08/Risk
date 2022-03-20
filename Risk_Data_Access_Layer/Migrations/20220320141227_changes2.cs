using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MobilePhones_MobileId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers",
                column: "MobileId",
                unique: true,
                filter: "[MobileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MobilePhones_MobileId",
                schema: "dbo",
                table: "Customers",
                column: "MobileId",
                principalSchema: "dbo",
                principalTable: "MobilePhones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
