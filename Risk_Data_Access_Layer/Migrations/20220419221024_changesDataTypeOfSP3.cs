using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Data_Access_Layer.Migrations
{
    public partial class changesDataTypeOfSP3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ANG_Call_Duration",
                table: "AgentReportResponseSP",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ANG_Call_Duration",
                table: "AgentReportResponseSP",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
