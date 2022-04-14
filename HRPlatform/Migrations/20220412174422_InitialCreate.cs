using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPlatform.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Skill_Candidate_CandidateName",
                        column: x => x.CandidateName,
                        principalTable: "Candidate",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CandidateName",
                table: "Skill",
                column: "CandidateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Candidate");
        }
    }
}
