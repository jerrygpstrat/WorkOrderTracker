using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AmountToPayOnWorkOrder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmoutToPay",
                table: "WorkOrders",
                newName: "AmountToPay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountToPay",
                table: "WorkOrders",
                newName: "AmoutToPay");
        }
    }
}
