using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PubHealth.Migrations
{
    /// <inheritdoc />
    public partial class transitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ParentSlideId = table.Column<int>(type: "int", nullable: false),
                    ChildSlideId = table.Column<int>(type: "int", nullable: false),
                    AnswerText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerText2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Category", "IsFork", "QuestionText", "SlideImageUrl", "SlideText" },
                values: new object[] { 3, "Test", false, "Why?", "testurl.com", "TestSlide3" });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Id", "AnswerText1", "AnswerText2", "ChildSlideId", "ParentSlideId" },
                values: new object[,]
                {
                    { 1, "Answer1", "Answer2", 2, 1 },
                    { 2, "Answer3", "Answer4", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
