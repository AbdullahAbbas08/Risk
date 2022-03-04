using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class addvirtualModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallReasonClient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ClientCalls");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                schema: "dbo",
                table: "CallReasons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallReasons_ClientId",
                schema: "dbo",
                table: "CallReasons",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CallReasons_Clients_ClientId",
                schema: "dbo",
                table: "CallReasons",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallReasons_Clients_ClientId",
                schema: "dbo",
                table: "CallReasons");

            migrationBuilder.DropIndex(
                name: "IX_CallReasons_ClientId",
                schema: "dbo",
                table: "CallReasons");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "dbo",
                table: "CallReasons");

            migrationBuilder.CreateTable(
                name: "CallReasonClient",
                schema: "dbo",
                columns: table => new
                {
                    CallReasonsId = table.Column<int>(type: "int", nullable: false),
                    ClientsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallReasonClient", x => new { x.CallReasonsId, x.ClientsId });
                    table.ForeignKey(
                        name: "FK_CallReasonClient_CallReasons_CallReasonsId",
                        column: x => x.CallReasonsId,
                        principalSchema: "dbo",
                        principalTable: "CallReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallReasonClient_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalSchema: "dbo",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallId = table.Column<int>(type: "int", nullable: false),
                    @string = table.Column<string>(name: "string", type: "nvarchar(450)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_CallReasonClient_ClientsId",
                schema: "dbo",
                table: "CallReasonClient",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCalls_CallId",
                table: "ClientCalls",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCalls_string",
                table: "ClientCalls",
                column: "string");
        }
    }
}
