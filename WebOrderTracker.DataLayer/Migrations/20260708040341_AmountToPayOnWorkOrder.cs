using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AmountToPayOnWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmoutToPay",
                table: "WorkOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmoutToPay",
                table: "WorkOrders");
        }
    }
}
