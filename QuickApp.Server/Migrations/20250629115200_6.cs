using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "BaseEntity");

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
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_Payments",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_Payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_Payments",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_Payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_OrganizationAccounts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_OrganizationAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_OrganizationAccounts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_OrganizationAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_Items",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_Items",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_Customers",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_Customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_Customers",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_Customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_CustomerAccounts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_CustomerAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_CustomerAccounts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_CustomerAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_Contracts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_Contracts",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Banks",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment_C_Banks",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payment_C_Banks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment_C_Banks",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment_C_Banks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_UserToClient",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Global_C_UserToClient",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Global_C_UserToClient",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Global_C_UserToClient",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Global_C_UserToClient",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_Organizations",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Global_C_Organizations",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Global_C_Organizations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Global_C_Organizations",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Global_C_Organizations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_Clients",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()",
                oldComment: "Идентификатор");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Global_C_Clients",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Global_C_Clients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Global_C_Clients",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Global_C_Clients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Global_C_UserToClient");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Global_C_UserToClient");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Global_C_UserToClient");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Global_C_UserToClient");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Global_C_Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Global_C_Organizations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Global_C_Organizations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Global_C_Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Global_C_Clients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Global_C_Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Global_C_Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Global_C_Clients");

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
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_CustomerAccounts",
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
                table: "Payment_C_Contracts",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payment_C_Banks",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_UserToClient",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_Organizations",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Global_C_Clients",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

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
    }
}
