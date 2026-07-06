using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AppVars2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsePrefix",
                table: "AppVars",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsePrefix",
                table: "AppVars");
        }
    }
}
