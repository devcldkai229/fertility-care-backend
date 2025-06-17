using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FertilityCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class delNotesAndEggGradeAndAddReferenceInEmbryoTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EggGrade",
                table: "EmbryoTransfer");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "EmbryoTransfer");

            migrationBuilder.DropColumn(
                name: "PregnancyResultNote",
                table: "EmbryoTransfer");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "EmbryoTransfer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EmbryoTransfer_OrderId",
                table: "EmbryoTransfer",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmbryoTransfer_Order_OrderId",
                table: "EmbryoTransfer",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmbryoTransfer_Order_OrderId",
                table: "EmbryoTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmbryoTransfer_OrderId",
                table: "EmbryoTransfer");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "EmbryoTransfer");

            migrationBuilder.AddColumn<string>(
                name: "EggGrade",
                table: "EmbryoTransfer",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "EmbryoTransfer",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PregnancyResultNote",
                table: "EmbryoTransfer",
                type: "ntext",
                nullable: true);
        }
    }
}
