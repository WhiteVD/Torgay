using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torgay.Server.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_Id",
                table: "Payment_C_Banks");

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

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Payment_C_Banks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Country_id",
                table: "Payment_C_Banks",
                type: "uuid",
                nullable: true,
                comment: "Страна");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_Banks_CountryId",
                table: "Payment_C_Banks",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Banks_Payment_C_Countries_CountryId",
                table: "Payment_C_Banks",
                column: "CountryId",
                principalTable: "Payment_C_Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_C_Banks_Payment_C_Countries_CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.DropIndex(
                name: "IX_Payment_C_Banks_CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Payment_C_Banks");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "Payment_C_Banks");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_C_Banks_BaseEntity_Id",
                table: "Payment_C_Banks",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
