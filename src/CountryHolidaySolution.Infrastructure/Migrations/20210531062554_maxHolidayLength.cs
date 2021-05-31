using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    public partial class maxHolidayLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayStatuses_CustomDayType_DayTypeId",
                table: "DayStatuses");

            migrationBuilder.DropTable(
                name: "CustomDayType");

            migrationBuilder.CreateTable(
                name: "HolidayPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MaxHolidayLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkDayType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWorkDay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDayType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DayStatuses_WorkDayType_DayTypeId",
                table: "DayStatuses",
                column: "DayTypeId",
                principalTable: "WorkDayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayStatuses_WorkDayType_DayTypeId",
                table: "DayStatuses");

            migrationBuilder.DropTable(
                name: "HolidayPeriods");

            migrationBuilder.DropTable(
                name: "WorkDayType");

            migrationBuilder.CreateTable(
                name: "CustomDayType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWorkDay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDayType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DayStatuses_CustomDayType_DayTypeId",
                table: "DayStatuses",
                column: "DayTypeId",
                principalTable: "CustomDayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
