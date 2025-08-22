using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Global_C_Organizations_organizat~",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Customers_Global_C_Organizations_organizationId",
                table: "Payment_C_Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Global_C_Organizations_organ~",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_OrganizationAccounts_organizationId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Customers_organizationId",
                table: "Payment_C_Customers");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_organizationId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "organizationId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "organizationId",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "organizationId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Payment_C_Payments",
                newName: "Source_id");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Payment_C_Payments",
                newName: "Organization_id");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Payment_C_Customers",
                newName: "Source_id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Payment_C_PPC",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                comment: "Наименование",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldComment: "Наименование");

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Организация");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment_C_OrganizationAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Удалён?");

            migrationBuilder.AddColumn<Guid>(
                name: "Source_id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор источника");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment_C_Items",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Удалён?");

            migrationBuilder.AddColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "Source_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор источника");

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Организация");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Организация");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment_C_CustomerAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Удалён?");

            migrationBuilder.AddColumn<Guid>(
                name: "Source_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор источника");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "Source_id",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "Organization_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "Source_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "Source_id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.RenameColumn(
                name: "Source_id",
                table: "Payment_C_Payments",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "Organization_id",
                table: "Payment_C_Payments",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "Source_id",
                table: "Payment_C_Customers",
                newName: "SourceId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Payment_C_PPC",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                comment: "Наименование",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldComment: "Наименование");

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Организация",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "organizationId",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Организация",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "organizationId",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Organization_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Организация",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Клиент");

            migrationBuilder.AddColumn<Guid>(
                name: "customerId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "organizationId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_OrganizationAccounts_organizationId",
                table: "Payment_C_OrganizationAccounts",
                column: "organizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Customers_organizationId",
                table: "Payment_C_Customers",
                column: "organizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_organizationId",
                table: "Payment_C_CustomerAccounts",
                column: "organizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Global_C_Organizations_organizat~",
                table: "Payment_C_CustomerAccounts",
                column: "organizationId",
                principalTable: "Global_C_Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                table: "Payment_C_CustomerAccounts",
                column: "customerId",
                principalTable: "Payment_C_Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Customers_Global_C_Organizations_organizationId",
                table: "Payment_C_Customers",
                column: "organizationId",
                principalTable: "Global_C_Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Global_C_Organizations_organ~",
                table: "Payment_C_OrganizationAccounts",
                column: "organizationId",
                principalTable: "Global_C_Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
