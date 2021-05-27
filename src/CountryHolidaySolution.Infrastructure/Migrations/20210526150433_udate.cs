using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    public partial class udate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_FromDate_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ToDate_ToDateId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "FromDate");

            migrationBuilder.DropTable(
                name: "ToDate");

            migrationBuilder.DropIndex(
                name: "IX_Countries_FromDateId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_ToDateId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "FromDate_Day",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromDate_Id",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromDate_Month",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromDate_Year",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToDate_Day",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToDate_Id",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToDate_Month",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToDate_Year",
                table: "Countries",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate_Day",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "FromDate_Id",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "FromDate_Month",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "FromDate_Year",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ToDate_Day",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ToDate_Id",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ToDate_Month",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ToDate_Year",
                table: "Countries");

            migrationBuilder.CreateTable(
                name: "FromDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FromDateId",
                table: "Countries",
                column: "FromDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ToDateId",
                table: "Countries",
                column: "ToDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_FromDate_FromDateId",
                table: "Countries",
                column: "FromDateId",
                principalTable: "FromDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_ToDate_ToDateId",
                table: "Countries",
                column: "ToDateId",
                principalTable: "ToDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
