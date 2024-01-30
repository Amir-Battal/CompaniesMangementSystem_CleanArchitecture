using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Reportfrom",
                table: "produces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Reportto",
                table: "produces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to = table.Column<DateTime>(type: "datetime2", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => new { x.from, x.to });
                });

            migrationBuilder.CreateIndex(
                name: "IX_produces_Reportfrom_Reportto",
                table: "produces",
                columns: new[] { "Reportfrom", "Reportto" });

            migrationBuilder.AddForeignKey(
                name: "FK_produces_reports_Reportfrom_Reportto",
                table: "produces",
                columns: new[] { "Reportfrom", "Reportto" },
                principalTable: "reports",
                principalColumns: new[] { "from", "to" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produces_reports_Reportfrom_Reportto",
                table: "produces");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropIndex(
                name: "IX_produces_Reportfrom_Reportto",
                table: "produces");

            migrationBuilder.DropColumn(
                name: "Reportfrom",
                table: "produces");

            migrationBuilder.DropColumn(
                name: "Reportto",
                table: "produces");
        }
    }
}
