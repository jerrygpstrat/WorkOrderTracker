using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SomeFluentApi001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderParts_Parts_PartId",
                table: "WorkOrderParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrderParts",
                table: "WorkOrderParts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderParts_WorkOrderId",
                table: "WorkOrderParts");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "WorkOrders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrderParts",
                table: "WorkOrderParts",
                columns: new[] { "WorkOrderId", "PartId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderNumber",
                table: "WorkOrders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_SKU",
                table: "Parts",
                column: "SKU",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderParts_Parts_PartId",
                table: "WorkOrderParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderParts_Parts_PartId",
                table: "WorkOrderParts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_OrderNumber",
                table: "WorkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrderParts",
                table: "WorkOrderParts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_SKU",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrderParts",
                table: "WorkOrderParts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_WorkOrderId",
                table: "WorkOrderParts",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderParts_Parts_PartId",
                table: "WorkOrderParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
