using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prsistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypingTest",
                table: "TypingTest");

            migrationBuilder.RenameTable(
                name: "TypingTest",
                newName: "TypingResult");

            migrationBuilder.AddColumn<string>(
                name: "CorrectWords",
                table: "TypingResult",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WrongWords",
                table: "TypingResult",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypingResult",
                table: "TypingResult",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypingResult",
                table: "TypingResult");

            migrationBuilder.DropColumn(
                name: "CorrectWords",
                table: "TypingResult");

            migrationBuilder.DropColumn(
                name: "WrongWords",
                table: "TypingResult");

            migrationBuilder.RenameTable(
                name: "TypingResult",
                newName: "TypingTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypingTest",
                table: "TypingTest",
                column: "Id");
        }
    }
}
