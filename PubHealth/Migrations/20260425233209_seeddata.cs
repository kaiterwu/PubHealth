using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PubHealth.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Category", "IsFork", "QuestionText", "SlideImageUrl", "SlideText" },
                values: new object[,]
                {
                    { 1, "Test", false, "Hello?", "testurl.com", "TestSlide" },
                    { 2, "Test", false, "Hello?", "testurl.com", "TestSlide2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
