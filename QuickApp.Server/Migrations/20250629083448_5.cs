using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_Clients_BaseEntity_id",
                table: "Global_C_Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_Organizations_BaseEntity_id",
                table: "Global_C_Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_UserToClient_BaseEntity_id",
                table: "Global_C_UserToClient");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_id",
                table: "Payment_C_Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_BaseEntity_id",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_BaseEntity_id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Customers_BaseEntity_id",
                table: "Payment_C_Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Items_BaseEntity_id",
                table: "Payment_C_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_BaseEntity_id",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Payments_BaseEntity_id",
                table: "Payment_C_Payments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_OrganizationAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_CustomerAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_Contracts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payment_C_Banks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Global_C_UserToClient",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Global_C_Organizations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Global_C_Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BaseEntity",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_PPC",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_CurrencyRates",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Currency",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Countries",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_BCC",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_Clients_BaseEntity_Id",
                table: "Global_C_Clients",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_Organizations_BaseEntity_Id",
                table: "Global_C_Organizations",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_UserToClient_BaseEntity_Id",
                table: "Global_C_UserToClient",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_Id",
                table: "Payment_C_Banks",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Contracts_BaseEntity_Id",
                table: "Payment_C_Contracts",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_BaseEntity_Id",
                table: "Payment_C_CustomerAccounts",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Customers_BaseEntity_Id",
                table: "Payment_C_Customers",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Items_BaseEntity_Id",
                table: "Payment_C_Items",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_BaseEntity_Id",
                table: "Payment_C_OrganizationAccounts",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Payments_BaseEntity_Id",
                table: "Payment_C_Payments",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_Clients_BaseEntity_Id",
                table: "Global_C_Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_Organizations_BaseEntity_Id",
                table: "Global_C_Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Global_C_UserToClient_BaseEntity_Id",
                table: "Global_C_UserToClient");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_Id",
                table: "Payment_C_Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_BaseEntity_Id",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_BaseEntity_Id",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Customers_BaseEntity_Id",
                table: "Payment_C_Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Items_BaseEntity_Id",
                table: "Payment_C_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_BaseEntity_Id",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Payments_BaseEntity_Id",
                table: "Payment_C_Payments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_Payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_OrganizationAccounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_Items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_Customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_CustomerAccounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_Contracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment_C_Banks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Global_C_UserToClient",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Global_C_Organizations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Global_C_Clients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BaseEntity",
                newName: "id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_PPC",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_CurrencyRates",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Currency",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Countries",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_BCC",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_Clients_BaseEntity_id",
                table: "Global_C_Clients",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_Organizations_BaseEntity_id",
                table: "Global_C_Organizations",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Global_C_UserToClient_BaseEntity_id",
                table: "Global_C_UserToClient",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_id",
                table: "Payment_C_Banks",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Contracts_BaseEntity_id",
                table: "Payment_C_Contracts",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_BaseEntity_id",
                table: "Payment_C_CustomerAccounts",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Customers_BaseEntity_id",
                table: "Payment_C_Customers",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Items_BaseEntity_id",
                table: "Payment_C_Items",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_BaseEntity_id",
                table: "Payment_C_OrganizationAccounts",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Payments_BaseEntity_id",
                table: "Payment_C_Payments",
                column: "id",
                principalTable: "BaseEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
