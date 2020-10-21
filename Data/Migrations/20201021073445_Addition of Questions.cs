using Microsoft.EntityFrameworkCore.Migrations;

namespace ABTQuiz.Data.Migrations
{
    public partial class AdditionofQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    AnswerOne = table.Column<string>(nullable: false),
                    AnswerTwo = table.Column<string>(nullable: false),
                    AnswerThree = table.Column<string>(nullable: false),
                    AnswerFour = table.Column<string>(nullable: false),
                    CorrectAns = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestions");
        }
    }
}
