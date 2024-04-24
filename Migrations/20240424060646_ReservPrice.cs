using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_.Net_Core_Class_Home_Work.Migrations
{
    /// <inheritdoc />
    public partial class ReservPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDateTime",
                table: "Reservations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Reservations",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDateTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservations");
        }
    }
}
