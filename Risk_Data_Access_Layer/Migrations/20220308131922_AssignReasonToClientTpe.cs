using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class AssignReasonToClientTpe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CallReasonClientType",
                schema: "dbo",
                columns: table => new
                {
                    CallReasonsId = table.Column<int>(type: "int", nullable: false),
                    ClientTypeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallReasonClientType", x => new { x.CallReasonsId, x.ClientTypeTypeId });
                    table.ForeignKey(
                        name: "FK_CallReasonClientType_CallReasons_CallReasonsId",
                        column: x => x.CallReasonsId,
                        principalSchema: "dbo",
                        principalTable: "CallReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallReasonClientType_ClientTypes_ClientTypeTypeId",
                        column: x => x.ClientTypeTypeId,
                        principalSchema: "dbo",
                        principalTable: "ClientTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ClientCustomerServise",
                schema: "dbo",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCustomerServise", x => new { x.ClientId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ClientCustomerServise_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "dbo",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCustomerServise_CustomerServise_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "CustomerServise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallReasonClientType_ClientTypeTypeId",
                schema: "dbo",
                table: "CallReasonClientType",
                column: "ClientTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCustomerServise_CustomerId",
                schema: "dbo",
                table: "ClientCustomerServise",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallReasonClientType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ClientCustomerServise",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerServise",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

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
    }
}
