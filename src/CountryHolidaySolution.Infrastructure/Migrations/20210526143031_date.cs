using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    public partial class date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_FromDates_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ToDates_ToDateId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDates",
                table: "ToDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FromDates",
                table: "FromDates");

            migrationBuilder.RenameTable(
                name: "ToDates",
                newName: "ToDate");

            migrationBuilder.RenameTable(
                name: "FromDates",
                newName: "FromDate");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "ToDate",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "FromDate",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDate",
                table: "ToDate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FromDate",
                table: "FromDate",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_FromDate_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ToDate_ToDateId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDate",
                table: "ToDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FromDate",
                table: "FromDate");

            migrationBuilder.RenameTable(
                name: "ToDate",
                newName: "ToDates");

            migrationBuilder.RenameTable(
                name: "FromDate",
                newName: "FromDates");

            migrationBuilder.AlterColumn<long>(
                name: "Year",
                table: "ToDates",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Year",
                table: "FromDates",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDates",
                table: "ToDates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FromDates",
                table: "FromDates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_FromDates_FromDateId",
                table: "Countries",
                column: "FromDateId",
                principalTable: "FromDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_ToDates_ToDateId",
                table: "Countries",
                column: "ToDateId",
                principalTable: "ToDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
