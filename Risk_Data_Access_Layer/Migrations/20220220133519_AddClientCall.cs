using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class AddClientCall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    @string = table.Column<string>(name: "string", type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCalls_Call_CallId",
                        column: x => x.CallId,
                        principalTable: "Call",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCalls_Clients_string",
                        column: x => x.@string,
                        principalSchema: "dbo",
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCalls_CallId",
                table: "ClientCalls",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCalls_string",
                table: "ClientCalls",
                column: "string");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCalls");
        }
    }
}
