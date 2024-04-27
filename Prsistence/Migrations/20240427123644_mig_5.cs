using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prsistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "TypingExam",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "TypingExam",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "TypingExam",
                newName: "LanguageID");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "TypingExam",
                newName: "CategoryID");
        }
    }
}
