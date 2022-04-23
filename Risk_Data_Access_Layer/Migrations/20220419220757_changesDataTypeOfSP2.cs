using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class changesDataTypeOfSP2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ANG_Call_Duration",
                table: "AgentReportResponseSP",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ANG_Call_Duration",
                table: "AgentReportResponseSP",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
