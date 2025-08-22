using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Payment_C_Payments",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Номер");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Payment_C_MovementTypes",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "Наименование");

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Контрагент");

            migrationBuilder.AddColumn<Guid>(
                name: "customerId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                table: "Payment_C_CustomerAccounts",
                column: "customerId",
                principalTable: "Payment_C_Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Payment_C_MovementTypes");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Payment_C_CustomerAccounts");
        }
    }
}
