using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torgay.Server.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOrderDetails");

            migrationBuilder.DropTable(
                name: "AppOrders");

            migrationBuilder.DropTable(
                name: "AppProducts");

            migrationBuilder.DropTable(
                name: "AppCustomers");

            migrationBuilder.DropTable(
                name: "AppProductCategories");

            migrationBuilder.CreateTable(
                name: "Global_C_Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_C_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Global_C_UserToClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_C_UserToClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_AccountType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    BIC = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "Банковский идентификационный код"),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_ContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    ISO = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, comment: "ISO код")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Организация"),
                    organizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_Customers_Global_C_Organizations_organizationId",
                        column: x => x.organizationId,
                        principalTable: "Global_C_Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_MovementTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_MovementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата"),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    currencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false, comment: "Курс")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_CurrencyRates_Payment_C_Currency_currencyId",
                        column: x => x.currencyId,
                        principalTable: "Payment_C_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_OrganizationAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    AccountType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Тип счёта"),
                    accountTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    currencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Bank_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Банк"),
                    bankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Организация"),
                    organizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_OrganizationAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_OrganizationAccounts_Global_C_Organizations_organ~",
                        column: x => x.organizationId,
                        principalTable: "Global_C_Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_OrganizationAccounts_Payment_C_AccountType_accoun~",
                        column: x => x.accountTypeId,
                        principalTable: "Payment_C_AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_OrganizationAccounts_Payment_C_Banks_bankId",
                        column: x => x.bankId,
                        principalTable: "Payment_C_Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_OrganizationAccounts_Payment_C_Currency_currencyId",
                        column: x => x.currencyId,
                        principalTable: "Payment_C_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_CustomerAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    AccountType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Тип счёта"),
                    accountTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    currencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Bank_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Банк"),
                    bankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Customer_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Клиент"),
                    customerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Организация"),
                    organizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_CustomerAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_Global_C_Organizations_organizat~",
                        column: x => x.organizationId,
                        principalTable: "Global_C_Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_Payment_C_AccountType_accountTyp~",
                        column: x => x.accountTypeId,
                        principalTable: "Payment_C_AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_Payment_C_Banks_bankId",
                        column: x => x.bankId,
                        principalTable: "Payment_C_Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_Payment_C_Currency_currencyId",
                        column: x => x.currencyId,
                        principalTable: "Payment_C_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_Payment_C_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Payment_C_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_CurrencyRates_currencyId",
                table: "Payment_C_CurrencyRates",
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
                name: "IX_Payment_C_CustomerAccounts_organizationId",
                table: "Payment_C_CustomerAccounts",
                column: "organizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Customers_organizationId",
                table: "Payment_C_Customers",
                column: "organizationId");

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
                name: "IX_Payment_C_OrganizationAccounts_organizationId",
                table: "Payment_C_OrganizationAccounts",
                column: "organizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Global_C_Clients");

            migrationBuilder.DropTable(
                name: "Global_C_UserToClient");

            migrationBuilder.DropTable(
                name: "Payment_C_Contracts");

            migrationBuilder.DropTable(
                name: "Payment_C_ContractTypes");

            migrationBuilder.DropTable(
                name: "Payment_C_Countries");

            migrationBuilder.DropTable(
                name: "Payment_C_CurrencyRates");

            migrationBuilder.DropTable(
                name: "Payment_C_CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Payment_C_Items");

            migrationBuilder.DropTable(
                name: "Payment_C_MovementTypes");

            migrationBuilder.DropTable(
                name: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropTable(
                name: "Payment_C_Payments");

            migrationBuilder.DropTable(
                name: "Payment_C_Customers");

            migrationBuilder.DropTable(
                name: "Payment_C_AccountType");

            migrationBuilder.DropTable(
                name: "Payment_C_Banks");

            migrationBuilder.DropTable(
                name: "Payment_C_Currency");

            migrationBuilder.CreateTable(
                name: "AppCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    CashierId = table.Column<string>(type: "text", nullable: true),
                    CustomerId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    Comments = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrders_AppCustomers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "AppCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrders_AspNetUsers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    ParentId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductCategoryId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDiscontinued = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    UnitsInStock = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppProducts_AppProductCategories_ProductCategoryId1",
                        column: x => x.ProductCategoryId1,
                        principalTable: "AppProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppProducts_AppProducts_ParentId1",
                        column: x => x.ParentId1,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppOrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    OrderId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrderDetails_AppOrders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrderDetails_AppProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_Name",
                table: "AppCustomers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderDetails_OrderId1",
                table: "AppOrderDetails",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderDetails_ProductId1",
                table: "AppOrderDetails",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_CashierId",
                table: "AppOrders",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_CustomerId1",
                table: "AppOrders",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_Name",
                table: "AppProducts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_ParentId1",
                table: "AppProducts",
                column: "ParentId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_ProductCategoryId1",
                table: "AppProducts",
                column: "ProductCategoryId1");
        }
    }
}
