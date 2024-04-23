using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_.Net_Core_Class_Home_Work.Migrations
{
    /// <inheritdoc />
    public partial class RoomPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DailyPrice",
                table: "rooms",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "rooms");
        }
    }
}
