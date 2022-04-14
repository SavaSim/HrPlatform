using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPlatform.Migrations
{
    public partial class IdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Candidate_CandidateName",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CandidateName",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateName",
                table: "Skill");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Skill",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candidate",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Candidate",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CandidateSkill",
                columns: table => new
                {
                    CandidatesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkill", x => new { x.CandidatesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Candidate_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_SkillsId",
                table: "CandidateSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Candidate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateName",
                table: "Skill",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candidate",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CandidateName",
                table: "Skill",
                column: "CandidateName");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Candidate_CandidateName",
                table: "Skill",
                column: "CandidateName",
                principalTable: "Candidate",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
