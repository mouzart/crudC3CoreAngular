using Microsoft.EntityFrameworkCore.Migrations;

namespace MouzartSamuelBacarinEasy.Migrations
{
    public partial class correcaoemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");
        }
    }
}
