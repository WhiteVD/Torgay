using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torgay.Server.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDate",
                table: "Payment_C_Payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Фактическая дата");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payment_C_Payments",
                type: "numeric(19,2)",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Сумма платежа");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInCurrency",
                table: "Payment_C_Payments",
                type: "numeric(19,2)",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Сумма платежа в валюте");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AddColumn<Guid>(
                name: "Contract_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор договора");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Идентификатор валюты");

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор контрагента получателя/отправителя");

            migrationBuilder.AddColumn<DateTime>(
                name: "IncomeDate",
                table: "Payment_C_Payments",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата поступления");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment_C_Payments",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Удалён?");

            migrationBuilder.AddColumn<string>(
                name: "KbkCode",
                table: "Payment_C_Payments",
                type: "text",
                nullable: true,
                comment: "КБК");

            migrationBuilder.AddColumn<string>(
                name: "KnpCode",
                table: "Payment_C_Payments",
                type: "text",
                nullable: true,
                comment: "КНП");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Payment_C_Payments",
                type: "text",
                nullable: true,
                comment: "Примечание");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentPaymentId",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentPayment_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор родительского платежа");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentCategory_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Вид платежа");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedDate",
                table: "Payment_C_Payments",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Прогнозная дата оплаты");

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfPayment",
                table: "Payment_C_Payments",
                type: "text",
                nullable: true,
                comment: "Назначение платежа");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientAccount_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор счёта получателя");

            migrationBuilder.AddColumn<Guid>(
                name: "SenderAccountId",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор счёта отправителя");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор источника");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payment_C_Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Статус платежа");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Payment_C_Payments",
                type: "numeric(19,2)",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Общая сумма");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountInCurrency",
                table: "Payment_C_Payments",
                type: "numeric(19,2)",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Общая сумма в валюте");

            migrationBuilder.AddColumn<Guid>(
                name: "TransferPair_id",
                table: "Payment_C_Payments",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор пары");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Payment_C_Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Тип платежа");

            migrationBuilder.AddColumn<double>(
                name: "VatRate",
                table: "Payment_C_Payments",
                type: "double precision",
                nullable: true,
                comment: "Ставка НДС");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Payment_C_ContractTypes",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Наименование");

            migrationBuilder.AddColumn<Guid>(
                name: "Client_id",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор клиента");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTypeId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractType_id",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Тип договора");

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_id",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Идентификатор контрагента");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Payment_C_Contracts",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата договора");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Payment_C_Contracts",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата окончания");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment_C_Contracts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Удалён?");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Payment_C_Contracts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Payment_C_Contracts",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Номер договора");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор организации");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор с 1С");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Payment_C_Contracts",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата начала");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payment_C_Contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Статус");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Payment_C_Contracts",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Наименование");

            migrationBuilder.AddColumn<Guid>(
                name: "customerId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payment_C_BCC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false, comment: "Код"),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_BCC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_PPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, comment: "Код"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_PPC", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Payments_CurrencyId",
                table: "Payment_C_Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Payments_ParentPaymentId",
                table: "Payment_C_Payments",
                column: "ParentPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Contracts_ContractTypeId",
                table: "Payment_C_Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Contracts_customerId",
                table: "Payment_C_Contracts",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_ContractTypes_ContractTypeId",
                table: "Payment_C_Contracts",
                column: "ContractTypeId",
                principalTable: "Payment_C_ContractTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_Customers_customerId",
                table: "Payment_C_Contracts",
                column: "customerId",
                principalTable: "Payment_C_Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Payments_Payment_C_Currency_CurrencyId",
                table: "Payment_C_Payments",
                column: "CurrencyId",
                principalTable: "Payment_C_Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Payments_Payment_C_Payments_ParentPaymentId",
                table: "Payment_C_Payments",
                column: "ParentPaymentId",
                principalTable: "Payment_C_Payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_ContractTypes_ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_Customers_customerId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Payments_Payment_C_Currency_CurrencyId",
                table: "Payment_C_Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Payments_Payment_C_Payments_ParentPaymentId",
                table: "Payment_C_Payments");

            migrationBuilder.DropTable(
                name: "Payment_C_BCC");

            migrationBuilder.DropTable(
                name: "Payment_C_PPC");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Payments_CurrencyId",
                table: "Payment_C_Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Payments_ParentPaymentId",
                table: "Payment_C_Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Contracts_ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Contracts_customerId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "ActualDate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "AmountInCurrency",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Contract_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "IncomeDate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "KbkCode",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "KnpCode",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "ParentPaymentId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "ParentPayment_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "PaymentCategory_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "PlannedDate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "PurposeOfPayment",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "RecipientAccount_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "SenderAccountId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "TotalAmountInCurrency",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "TransferPair_id",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Payment_C_Payments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Payment_C_ContractTypes");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "ContractType_id",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Payment_C_Contracts");
        }
    }
}
