using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FertilityCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingPStatusAndTAmountOrderSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "OrderStep",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "OrderStep",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "OrderStep");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "OrderStep");
        }
    }
}
