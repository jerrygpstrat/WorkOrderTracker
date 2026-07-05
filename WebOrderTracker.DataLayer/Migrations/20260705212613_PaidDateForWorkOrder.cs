using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class PaidDateForWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWorkPaid",
                table: "WorkOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "WorkOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWorkPaid",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "WorkOrders");
        }
    }
}
