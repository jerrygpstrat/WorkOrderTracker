using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrderTracker.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAssetAndTechnitianFromWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Assets_AssetId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Technicians_AssignedTechnicianId",
                table: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "AssignedTechnicianId",
                table: "WorkOrders",
                newName: "TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_AssignedTechnicianId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_TechnicianId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssetId",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Assets_AssetId",
                table: "WorkOrders",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Technicians_TechnicianId",
                table: "WorkOrders",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Assets_AssetId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Technicians_TechnicianId",
                table: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "TechnicianId",
                table: "WorkOrders",
                newName: "AssignedTechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_TechnicianId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_AssignedTechnicianId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssetId",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Assets_AssetId",
                table: "WorkOrders",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Technicians_AssignedTechnicianId",
                table: "WorkOrders",
                column: "AssignedTechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }
    }
}
