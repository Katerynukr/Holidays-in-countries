using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    public partial class dayType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DayStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayTypeId = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayStatuses_CustomDayType_DayTypeId",
                        column: x => x.DayTypeId,
                        principalTable: "CustomDayType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayStatuses_DayTypeId",
                table: "DayStatuses",
                column: "DayTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayStatuses");

            migrationBuilder.DropTable(
                name: "CustomDayType");
        }
    }
}
