using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class ProjectScrumMastertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Project_ProjectID",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_ProjectID",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.EnsureSchema(
                name: "ProjectScrumMasters");

            migrationBuilder.CreateTable(
                name: "ProjectScrumMaster",
                schema: "ProjectScrumMasters",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScrumMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectScrumMaster_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectScrumMaster_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Projects",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScrumMaster_CandidateId",
                schema: "ProjectScrumMasters",
                table: "ProjectScrumMaster",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScrumMaster_ProjectId",
                schema: "ProjectScrumMasters",
                table: "ProjectScrumMaster",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectScrumMaster",
                schema: "ProjectScrumMasters");

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ProjectID",
                schema: "Candidates",
                table: "Candidate",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Project_ProjectID",
                schema: "Candidates",
                table: "Candidate",
                column: "ProjectID",
                principalSchema: "Projects",
                principalTable: "Project",
                principalColumn: "ID");
        }
    }
}
