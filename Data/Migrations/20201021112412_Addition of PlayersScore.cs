using Microsoft.EntityFrameworkCore.Migrations;

namespace ABTQuiz.Data.Migrations
{
    public partial class AdditionofPlayersScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerScores",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AnswerToQOne = table.Column<string>(nullable: false),
                    AnswerToQTwo = table.Column<string>(nullable: false),
                    AnswerToQThree = table.Column<string>(nullable: false),
                    AnswerToQFour = table.Column<string>(nullable: false),
                    AnswerToQFive = table.Column<string>(nullable: false),
                    AnswerToQSix = table.Column<string>(nullable: false),
                    AnswerToQSeven = table.Column<string>(nullable: false),
                    AnswerToQEight = table.Column<string>(nullable: false),
                    AnswerToQNine = table.Column<string>(nullable: false),
                    AnswerToQTen = table.Column<string>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerScores");
        }
    }
}
