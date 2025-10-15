using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Torgay.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Configuration = table.Column<string>(type: "text", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    CreatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true, comment: "Кем создано"),
                    UpdatedBy = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true, comment: "Кем изменено"),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Когда изменено"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Когда создано")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                },
                comment: "Банковская выписка");

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    ClientType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "text", nullable: true),
                    Permissions = table.Column<string>(type: "text", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedirectUris = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true),
                    Settings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Resources = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
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
                },
                comment: "Тип счёта");

            migrationBuilder.CreateTable(
                name: "Payment_C_Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    BIC = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "Банковский идентификационный код"),
                    Country_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Страна"),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Banks", x => x.Id);
                },
                comment: "Банки");

            migrationBuilder.CreateTable(
                name: "Payment_C_BCC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false, comment: "Код"),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_BCC", x => x.Id);
                },
                comment: "Код бюджетной класификации");

            migrationBuilder.CreateTable(
                name: "Payment_C_ContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_ContractTypes", x => x.Id);
                },
                comment: "Тип договора");

            migrationBuilder.CreateTable(
                name: "Payment_C_Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Countries", x => x.Id);
                },
                comment: "Страны");

            migrationBuilder.CreateTable(
                name: "Payment_C_Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    ISO = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true, comment: "ISO код"),
                    Symbol = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true, comment: "Символ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Currency", x => x.Id);
                },
                comment: "Валюты");

            migrationBuilder.CreateTable(
                name: "Payment_C_CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата"),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false, comment: "Курс")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_CurrencyRates", x => x.Id);
                },
                comment: "Курсы валют");

            migrationBuilder.CreateTable(
                name: "Payment_C_MovementTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_MovementTypes", x => x.Id);
                },
                comment: "Вид движения");

            migrationBuilder.CreateTable(
                name: "Payment_C_PPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, comment: "Код"),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_PPC", x => x.Id);
                },
                comment: "Код назначения платежа");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Global_C_Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_C_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Global_C_Clients_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Global_C_Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Source_Id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    BIN = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true, comment: "БИН"),
                    Is_Deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_C_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Global_C_Organizations_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Global_C_UserToClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_C_UserToClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Global_C_UserToClient_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_C_Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор с 1С"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    Number = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Номер договора"),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата договора"),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата начала"),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата окончания"),
                    ContractType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Тип договора"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "Статус"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Customer_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор контрагента"),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_Contracts_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Договора");

            migrationBuilder.CreateTable(
                name: "Payment_C_CustomerAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Customer_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Контрагент"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    AccountType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Тип счёта"),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    Bank_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Банк"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_CustomerAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_CustomerAccounts_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Счета контрагентов");

            migrationBuilder.CreateTable(
                name: "Payment_C_Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Наименование"),
                    BIN = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false, comment: "БИН"),
                    Country_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Страна"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_Customers_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Контрагенты");

            migrationBuilder.CreateTable(
                name: "Payment_C_Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    MovetmentType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Вид движения"),
                    CashFlowCategory_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Категория ДДС"),
                    PnLCategory_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Категория ОПиУ"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_Items_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Статья");

            migrationBuilder.CreateTable(
                name: "Payment_C_OrganizationAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Наименование"),
                    AccountType_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Тип счёта"),
                    Currency_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Валюта"),
                    Bank_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Банк"),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_C_OrganizationAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_C_OrganizationAccounts_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Счета организации");

            migrationBuilder.CreateTable(
                name: "Payment_D_BankStatement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()", comment: "Идентификатор"),
                    AccountNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FinalBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    LastMovementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatementOrganizationBin = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    StatementOrganizationName = table.Column<string>(type: "text", nullable: false),
                    Client_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор клиента"),
                    Organization_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор организации"),
                    Source_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Идентификатор источника"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён?")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_D_BankStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_D_BankStatement_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Банковская выписка");

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

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Scopes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_Application~",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankStatementId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RecipientName = table.Column<string>(type: "text", nullable: true),
                    RecipientBinInn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    RecipientIik = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RecipientBankBik = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RecipientKbe = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PayerName = table.Column<string>(type: "text", nullable: true),
                    PayerBinInn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    PayerIik = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PayerBankBik = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PayerKbe = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Debit = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PaymentPurpose = table.Column<string>(type: "text", nullable: false),
                    PaymentCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Payment_D_BankStatement_BankStatementId",
                        column: x => x.BankStatementId,
                        principalTable: "Payment_D_BankStatement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReferenceId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankStatementId",
                table: "BankTransactions",
                column: "BankStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "Global_C_Clients");

            migrationBuilder.DropTable(
                name: "Global_C_Organizations");

            migrationBuilder.DropTable(
                name: "Global_C_UserToClient");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "Payment_C_AccountType");

            migrationBuilder.DropTable(
                name: "Payment_C_Banks");

            migrationBuilder.DropTable(
                name: "Payment_C_BCC");

            migrationBuilder.DropTable(
                name: "Payment_C_Contracts");

            migrationBuilder.DropTable(
                name: "Payment_C_ContractTypes");

            migrationBuilder.DropTable(
                name: "Payment_C_Countries");

            migrationBuilder.DropTable(
                name: "Payment_C_Currency");

            migrationBuilder.DropTable(
                name: "Payment_C_CurrencyRates");

            migrationBuilder.DropTable(
                name: "Payment_C_CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Payment_C_Customers");

            migrationBuilder.DropTable(
                name: "Payment_C_Items");

            migrationBuilder.DropTable(
                name: "Payment_C_MovementTypes");

            migrationBuilder.DropTable(
                name: "Payment_C_OrganizationAccounts");

            migrationBuilder.DropTable(
                name: "Payment_C_PPC");

            migrationBuilder.DropTable(
                name: "Payment_D_Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Payment_D_BankStatement");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
