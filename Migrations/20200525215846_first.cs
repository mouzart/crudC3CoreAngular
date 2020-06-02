using Microsoft.EntityFrameworkCore.Migrations;

namespace MouzartSamuelBacarinEasy.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Portfolio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkLoads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerDayUpTo4 = table.Column<bool>(nullable: false),
                    PerDay4To6 = table.Column<bool>(nullable: false),
                    PerDay6To8 = table.Column<bool>(nullable: false),
                    PerDayUpTo8 = table.Column<bool>(nullable: false),
                    OnlyWeeKend = table.Column<bool>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkLoads_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Morning = table.Column<bool>(nullable: false),
                    Afternoon = table.Column<bool>(nullable: false),
                    Night = table.Column<bool>(nullable: false),
                    Dawn = table.Column<bool>(nullable: false),
                    Business = table.Column<bool>(nullable: false),
                    HourlySalaryRequirement = table.Column<int>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateKnowledges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    KnowledgeId = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateKnowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateKnowledges_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateKnowledges_Knowledges_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowledges_CandidateId",
                table: "CandidateKnowledges",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowledges_KnowledgeId",
                table: "CandidateKnowledges",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLoads_CandidateId",
                table: "WorkLoads",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_CandidateId",
                table: "WorkSchedules",
                column: "CandidateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateKnowledges");

            migrationBuilder.DropTable(
                name: "WorkLoads");

            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
