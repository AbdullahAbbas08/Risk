using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ClientCustomerServise",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCustomerServise", x => new { x.ClientId, x.CustomerId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCustomerServise");

            migrationBuilder.CreateTable(
                name: "ClientCustomerService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerServiseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCustomerService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCustomerService_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "dbo",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCustomerService_CustomerServise_CustomerServiseId",
                        column: x => x.CustomerServiseId,
                        principalSchema: "dbo",
                        principalTable: "CustomerServise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCustomerService_ClientId",
                table: "ClientCustomerService",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCustomerService_CustomerServiseId",
                table: "ClientCustomerService",
                column: "CustomerServiseId");
        }
    }
}
