using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Customers_CustomerId",
                table: "ClientCustomerServise");

            migrationBuilder.DropTable(
                name: "CustomerServise",
                schema: "dbo");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise");

            migrationBuilder.CreateTable(
                name: "CustomerServise",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerServise_Employees_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Customers_CustomerId",
                table: "ClientCustomerServise",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
