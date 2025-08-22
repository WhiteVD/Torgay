using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISO",
                table: "Payment_C_Currency",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true,
                comment: "ISO код",
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3,
                oldComment: "ISO код");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Payment_C_Currency",
                type: "character varying(4)",
                maxLength: 4,
                nullable: true,
                comment: "Символ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Payment_C_Currency");

            migrationBuilder.AlterColumn<string>(
                name: "ISO",
                table: "Payment_C_Currency",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "ISO код",
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "ISO код");
        }
    }
}
