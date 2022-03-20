using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPhones");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "IdentityUser");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                schema: "dbo",
                table: "MobilePhones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_CustomerId",
                schema: "dbo",
                table: "MobilePhones",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers",
                column: "MobileId",
                unique: true,
                filter: "[MobileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones");

            migrationBuilder.DropIndex(
                name: "IX_MobilePhones_CustomerId",
                schema: "dbo",
                table: "MobilePhones");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "MobilePhones");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerPhones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhones", x => x.id);
                    table.ForeignKey(
                        name: "FK_CustomerPhones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerPhones_MobilePhones_MobileId",
                        column: x => x.MobileId,
                        principalSchema: "dbo",
                        principalTable: "MobilePhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MobileId",
                schema: "dbo",
                table: "Customers",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_CustomerId",
                table: "CustomerPhones",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_MobileId",
                table: "CustomerPhones",
                column: "MobileId");
        }
    }
}
