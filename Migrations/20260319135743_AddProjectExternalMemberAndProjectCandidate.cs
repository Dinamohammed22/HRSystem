using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectExternalMemberAndProjectCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProjectCandidates");

            migrationBuilder.EnsureSchema(
                name: "ProjectExternalMembers");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                schema: "CloseProjects",
                table: "CloseProject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProjectCandidate",
                schema: "ProjectCandidates",
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
                    table.PrimaryKey("PK_ProjectCandidate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectCandidate_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectCandidate_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Projects",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectExternalMember",
                schema: "ProjectExternalMembers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExternalMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectExternalMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectExternalMember_ExternalMember_ExternalMemberId",
                        column: x => x.ExternalMemberId,
                        principalSchema: "ExternalMember",
                        principalTable: "ExternalMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectExternalMember_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Projects",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeRequest_ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseProject_ProjectId",
                schema: "CloseProjects",
                table: "CloseProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCandidate_CandidateId",
                schema: "ProjectCandidates",
                table: "ProjectCandidate",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCandidate_ProjectId",
                schema: "ProjectCandidates",
                table: "ProjectCandidate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExternalMember_ExternalMemberId",
                schema: "ProjectExternalMembers",
                table: "ProjectExternalMember",
                column: "ExternalMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExternalMember_ProjectId",
                schema: "ProjectExternalMembers",
                table: "ProjectExternalMember",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloseProject_Project_ProjectId",
                schema: "CloseProjects",
                table: "CloseProject",
                column: "ProjectId",
                principalSchema: "Projects",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectChangeRequest_Project_ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "ProjectId",
                principalSchema: "Projects",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloseProject_Project_ProjectId",
                schema: "CloseProjects",
                table: "CloseProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectChangeRequest_Project_ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropTable(
                name: "ProjectCandidate",
                schema: "ProjectCandidates");

            migrationBuilder.DropTable(
                name: "ProjectExternalMember",
                schema: "ProjectExternalMembers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeRequest_ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropIndex(
                name: "IX_CloseProject_ProjectId",
                schema: "CloseProjects",
                table: "CloseProject");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "CloseProjects",
                table: "CloseProject");
        }
    }
}
