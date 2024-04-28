using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_.Net_Core_Class_Home_Work.Migrations
{
    /// <inheritdoc />
    public partial class Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDt",
                table: "users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDt",
                table: "Reservations",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DeleteDt",
                table: "Reservations");
        }
    }
}
