using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class AddAgentReportSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Call_CallReasons_CallReasonId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_SourceOfMarketing_SourceMarketId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_CallReasonClientType_CallReasons_CallReasonId",
                table: "CallReasonClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_CallReasonClientType_ClientTypes_ClientTypeId",
                table: "CallReasonClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Governorates_GovernorateId",
                schema: "dbo",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Clients_ClientId",
                table: "ClientCustomerServise");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityId",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.CreateTable(
                name: "AgentReportResponseSP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANG_Call_Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Call_CallReasons_CallReasonId",
                table: "Call",
                column: "CallReasonId",
                principalSchema: "dbo",
                principalTable: "CallReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call",
                column: "customerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call",
                column: "CustomerServiceId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_SourceOfMarketing_SourceMarketId",
                table: "Call",
                column: "SourceMarketId",
                principalSchema: "dbo",
                principalTable: "SourceOfMarketing",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CallReasonClientType_CallReasons_CallReasonId",
                table: "CallReasonClientType",
                column: "CallReasonId",
                principalSchema: "dbo",
                principalTable: "CallReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CallReasonClientType_ClientTypes_ClientTypeId",
                table: "CallReasonClientType",
                column: "ClientTypeId",
                principalSchema: "dbo",
                principalTable: "ClientTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Governorates_GovernorateId",
                schema: "dbo",
                table: "Cities",
                column: "GovernorateId",
                principalSchema: "dbo",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Clients_ClientId",
                table: "ClientCustomerServise",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cities_CityId",
                schema: "dbo",
                table: "Clients",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                schema: "dbo",
                table: "Clients",
                column: "ClientTypeId",
                principalSchema: "dbo",
                principalTable: "ClientTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityId",
                schema: "dbo",
                table: "Customers",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Call_CallReasons_CallReasonId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_Call_SourceOfMarketing_SourceMarketId",
                table: "Call");

            migrationBuilder.DropForeignKey(
                name: "FK_CallReasonClientType_CallReasons_CallReasonId",
                table: "CallReasonClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_CallReasonClientType_ClientTypes_ClientTypeId",
                table: "CallReasonClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Governorates_GovernorateId",
                schema: "dbo",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Clients_ClientId",
                table: "ClientCustomerServise");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityId",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "AgentReportResponseSP");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_CallReasons_CallReasonId",
                table: "Call",
                column: "CallReasonId",
                principalSchema: "dbo",
                principalTable: "CallReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Clients_ClientId",
                table: "Call",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Customers_customerId",
                table: "Call",
                column: "customerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Employees_CustomerServiceId",
                table: "Call",
                column: "CustomerServiceId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Call_SourceOfMarketing_SourceMarketId",
                table: "Call",
                column: "SourceMarketId",
                principalSchema: "dbo",
                principalTable: "SourceOfMarketing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallReasonClientType_CallReasons_CallReasonId",
                table: "CallReasonClientType",
                column: "CallReasonId",
                principalSchema: "dbo",
                principalTable: "CallReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallReasonClientType_ClientTypes_ClientTypeId",
                table: "CallReasonClientType",
                column: "ClientTypeId",
                principalSchema: "dbo",
                principalTable: "ClientTypes",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Governorates_GovernorateId",
                schema: "dbo",
                table: "Cities",
                column: "GovernorateId",
                principalSchema: "dbo",
                principalTable: "Governorates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Clients_ClientId",
                table: "ClientCustomerServise",
                column: "ClientId",
                principalSchema: "dbo",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCustomerServise_Employees_CustomerId",
                table: "ClientCustomerServise",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cities_CityId",
                schema: "dbo",
                table: "Clients",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                schema: "dbo",
                table: "Clients",
                column: "ClientTypeId",
                principalSchema: "dbo",
                principalTable: "ClientTypes",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityId",
                schema: "dbo",
                table: "Customers",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_Customers_CustomerId",
                schema: "dbo",
                table: "MobilePhones",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
