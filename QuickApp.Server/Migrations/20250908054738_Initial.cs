using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torgay.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Banks_Payment_C_Countries_CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_ContractTypes_ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Contracts_Payment_C_Customers_customerId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CurrencyRates_Payment_C_Currency_currencyId",
                table: "Payment_C_CurrencyRates");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_AccountType_accountTyp~",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Banks_bankId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Currency_currencyId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_AccountType_accoun~",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_Banks_bankId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_Currency_currencyId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropTable(
                name: "Payment_C_Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_OrganizationAccounts_accountTypeId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_OrganizationAccounts_bankId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_OrganizationAccounts_currencyId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_accountTypeId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_bankId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_currencyId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_CurrencyRates_currencyId",
                table: "Payment_C_CurrencyRates");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Contracts_ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Contracts_customerId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Banks_CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "accountTypeId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "bankId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropColumn(
                name: "accountTypeId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "bankId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Payment_C_CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "Payment_C_CurrencyRates");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Payment_C_Contracts");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.AlterTable(
                name: "Payment_C_PPC",
                comment: "Код назначения платежа");

            migrationBuilder.AlterTable(
                name: "Payment_C_OrganizationAccounts",
                comment: "Счета организации");

            migrationBuilder.AlterTable(
                name: "Payment_C_MovementTypes",
                comment: "Вид движения");

            migrationBuilder.AlterTable(
                name: "Payment_C_Items",
                comment: "Статья");

            migrationBuilder.AlterTable(
                name: "Payment_C_Customers",
                comment: "Контрагенты");

            migrationBuilder.AlterTable(
                name: "Payment_C_CustomerAccounts",
                comment: "Счета контрагентов");

            migrationBuilder.AlterTable(
                name: "Payment_C_CurrencyRates",
                comment: "Курсы валют");

            migrationBuilder.AlterTable(
                name: "Payment_C_Currency",
                comment: "Валюты");

            migrationBuilder.AlterTable(
                name: "Payment_C_Countries",
                comment: "Страны");

            migrationBuilder.AlterTable(
                name: "Payment_C_ContractTypes",
                comment: "Тип договора");

            migrationBuilder.AlterTable(
                name: "Payment_C_Contracts",
                comment: "Договора");

            migrationBuilder.AlterTable(
                name: "Payment_C_BCC",
                comment: "Код бюджетной класификации");

            migrationBuilder.AlterTable(
                name: "Payment_C_Banks",
                comment: "Банки");

            migrationBuilder.AlterTable(
                name: "Payment_C_AccountType",
                comment: "Тип счёта");

            migrationBuilder.AlterTable(
                name: "BaseEntity",
                comment: "Договора");

            migrationBuilder.AddColumn<Guid>(
                name: "CashFlowCategory_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Категория ДДС");

            migrationBuilder.AddColumn<Guid>(
                name: "MovetmentType_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Вид движения");

            migrationBuilder.AddColumn<Guid>(
                name: "PnLCategory_id",
                table: "Payment_C_Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Категория ОПиУ");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Payment_C_Items",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "Наименование");

            migrationBuilder.AddColumn<string>(
                name: "BIN",
                table: "Payment_C_Customers",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                comment: "БИН");

            migrationBuilder.AddColumn<Guid>(
                name: "Country_id",
                table: "Payment_C_Customers",
                type: "uuid",
                nullable: true,
                comment: "Страна");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Когда изменено",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BaseEntity",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                comment: "Кем изменено",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Когда создано",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "BaseEntity",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                comment: "Кем создано",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Payment_D_Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    PaymentId = table.Column<string>(type: "text", nullable: false, comment: "Номер"),
                    TotalAmount = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Общая сумма"),
                    Amount = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Сумма платежа"),
                    TotalAmountInCurrency = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Общая сумма в валюте"),
                    AmountInCurrency = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Сумма платежа в валюте"),
                    ParentPayment_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор родительского платежа"),
                    PlannedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Прогнозная дата оплаты"),
                    ActualDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Фактическая дата"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "Статус платежа"),
                    RecipientAccount_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор счёта получателя"),
                    SenderAccountId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор счёта отправителя"),
                    PaymentCategory_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Вид платежа"),
                    VatRate = table.Column<double>(type: "double precision", nullable: true, comment: "Ставка НДС"),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор валюты"),
                    Note = table.Column<string>(type: "text", nullable: true, comment: "Примечание"),
                    KnpCode = table.Column<string>(type: "text", nullable: true, comment: "КНП"),
                    KbkCode = table.Column<string>(type: "text", nullable: true, comment: "КБК"),
                    Contract_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор договора"),
                    Customer_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор контрагента получателя/отправителя"),
                    PurposeOfPayment = table.Column<string>(type: "text", nullable: true, comment: "Назначение платежа"),
                    TransferPair_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор пары"),
                    IncomeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата поступления"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_D_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_D_Payments_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Платежи");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment_D_Payments");

            migrationBuilder.DropColumn(
                name: "CashFlowCategory_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "MovetmentType_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "PnLCategory_id",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Payment_C_Items");

            migrationBuilder.DropColumn(
                name: "BIN",
                table: "Payment_C_Customers");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "Payment_C_Customers");

            migrationBuilder.AlterTable(
                name: "Payment_C_PPC",
                oldComment: "Код назначения платежа");

            migrationBuilder.AlterTable(
                name: "Payment_C_OrganizationAccounts",
                oldComment: "Счета организации");

            migrationBuilder.AlterTable(
                name: "Payment_C_MovementTypes",
                oldComment: "Вид движения");

            migrationBuilder.AlterTable(
                name: "Payment_C_Items",
                oldComment: "Статья");

            migrationBuilder.AlterTable(
                name: "Payment_C_Customers",
                oldComment: "Контрагенты");

            migrationBuilder.AlterTable(
                name: "Payment_C_CustomerAccounts",
                oldComment: "Счета контрагентов");

            migrationBuilder.AlterTable(
                name: "Payment_C_CurrencyRates",
                oldComment: "Курсы валют");

            migrationBuilder.AlterTable(
                name: "Payment_C_Currency",
                oldComment: "Валюты");

            migrationBuilder.AlterTable(
                name: "Payment_C_Countries",
                oldComment: "Страны");

            migrationBuilder.AlterTable(
                name: "Payment_C_ContractTypes",
                oldComment: "Тип договора");

            migrationBuilder.AlterTable(
                name: "Payment_C_Contracts",
                oldComment: "Договора");

            migrationBuilder.AlterTable(
                name: "Payment_C_BCC",
                oldComment: "Код бюджетной класификации");

            migrationBuilder.AlterTable(
                name: "Payment_C_Banks",
                oldComment: "Банки");

            migrationBuilder.AlterTable(
                name: "Payment_C_AccountType",
                oldComment: "Тип счёта");

            migrationBuilder.AlterTable(
                name: "BaseEntity",
                oldComment: "Договора");

            migrationBuilder.AddColumn<Guid>(
                name: "accountTypeId",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bankId",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currencyId",
                table: "Payment_C_OrganizationAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "accountTypeId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bankId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currencyId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "customerId",
                table: "Payment_C_CustomerAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currencyId",
                table: "Payment_C_CurrencyRates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTypeId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "customerId",
                table: "Payment_C_Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Payment_C_Banks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Когда изменено");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BaseEntity",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true,
                oldComment: "Кем изменено");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Когда создано");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "BaseEntity",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true,
                oldComment: "Кем создано");

            migrationBuilder.CreateTable(
                name: "Payment_C_Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор валюты"),
                    ParentPaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActualDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Фактическая дата"),
                    Amount = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Сумма платежа"),
                    AmountInCurrency = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Сумма платежа в валюте"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Contract_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор договора"),
                    Customer_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор контрагента получателя/отправителя"),
                    IncomeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата поступления"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?"),
                    KbkCode = table.Column<string>(type: "text", nullable: true, comment: "КБК"),
                    KnpCode = table.Column<string>(type: "text", nullable: true, comment: "КНП"),
                    Note = table.Column<string>(type: "text", nullable: true, comment: "Примечание"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    ParentPayment_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор родительского платежа"),
                    PaymentCategory_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Вид платежа"),
                    PaymentId = table.Column<string>(type: "text", nullable: false, comment: "Номер"),
                    PlannedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Прогнозная дата оплаты"),
                    PurposeOfPayment = table.Column<string>(type: "text", nullable: true, comment: "Назначение платежа"),
                    RecipientAccount_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор счёта получателя"),
                    SenderAccountId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор счёта отправителя"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "Статус платежа"),
                    TotalAmount = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Общая сумма"),
                    TotalAmountInCurrency = table.Column<decimal>(type: "numeric(19,2)", precision: 19, scale: 2, nullable: false, comment: "Общая сумма в валюте"),
                    TransferPair_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор пары"),
                    Type = table.Column<int>(type: "integer", nullable: false, comment: "Тип платежа"),
                    VatRate = table.Column<double>(type: "double precision", nullable: true, comment: "Ставка НДС")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_Payments_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_Payments_Payment_C_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Payment_C_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_Payments_Payment_C_Payments_ParentPaymentId",
                        column: x => x.ParentPaymentId,
                        principalTable: "Payment_C_Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_OrganizationAccounts_accountTypeId",
                table: "Payment_C_OrganizationAccounts",
                column: "accountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_OrganizationAccounts_bankId",
                table: "Payment_C_OrganizationAccounts",
                column: "bankId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_OrganizationAccounts_currencyId",
                table: "Payment_C_OrganizationAccounts",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_accountTypeId",
                table: "Payment_C_CustomerAccounts",
                column: "accountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_bankId",
                table: "Payment_C_CustomerAccounts",
                column: "bankId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_currencyId",
                table: "Payment_C_CustomerAccounts",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CustomerAccounts_customerId",
                table: "Payment_C_CustomerAccounts",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CurrencyRates_currencyId",
                table: "Payment_C_CurrencyRates",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Contracts_ContractTypeId",
                table: "Payment_C_Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Contracts_customerId",
                table: "Payment_C_Contracts",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Banks_CountryId",
                table: "Payment_C_Banks",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Payments_CurrencyId",
                table: "Payment_C_Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Payments_ParentPaymentId",
                table: "Payment_C_Payments",
                column: "ParentPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Banks_Payment_C_Countries_CountryId",
                table: "Payment_C_Banks",
                column: "CountryId",
                principalTable: "Payment_C_Countries",
                principalColumn: "Id");

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
                name: "FK_Payment_C_CurrencyRates_Payment_C_Currency_currencyId",
                table: "Payment_C_CurrencyRates",
                column: "currencyId",
                principalTable: "Payment_C_Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_AccountType_accountTyp~",
                table: "Payment_C_CustomerAccounts",
                column: "accountTypeId",
                principalTable: "Payment_C_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Banks_bankId",
                table: "Payment_C_CustomerAccounts",
                column: "bankId",
                principalTable: "Payment_C_Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_CustomerAccounts_Payment_C_Currency_currencyId",
                table: "Payment_C_CustomerAccounts",
                column: "currencyId",
                principalTable: "Payment_C_Currency",
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
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_AccountType_accoun~",
                table: "Payment_C_OrganizationAccounts",
                column: "accountTypeId",
                principalTable: "Payment_C_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_Banks_bankId",
                table: "Payment_C_OrganizationAccounts",
                column: "bankId",
                principalTable: "Payment_C_Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_OrganizationAccounts_Payment_C_Currency_currencyId",
                table: "Payment_C_OrganizationAccounts",
                column: "currencyId",
                principalTable: "Payment_C_Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
