using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddCloseProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectChangeRequest_ProjectChangeReason_ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropTable(
                name: "ProjectChangeReason",
                schema: "ProjectChangeReasons");

            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeRequest_ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropColumn(
                name: "ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.EnsureSchema(
                name: "CloseProjects");

            migrationBuilder.AddColumn<string>(
                name: "ProjectChangeReason",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CloseProject",
                schema: "CloseProjects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectCloseReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CloseDuration = table.Column<int>(type: "int", nullable: false),
                    HasCloseImpact = table.Column<bool>(type: "bit", nullable: false),
                    InternalCloseReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalCloseReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseProject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CloseProject_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloseProject_CandidateId",
                schema: "CloseProjects",
                table: "CloseProject",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CloseProject",
                schema: "CloseProjects");

            migrationBuilder.DropColumn(
                name: "ProjectChangeReason",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.EnsureSchema(
                name: "ProjectChangeReasons");

            migrationBuilder.AddColumn<string>(
                name: "ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectChangeReason",
                schema: "ProjectChangeReasons",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectChangeReason", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeRequest_ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "ProjectChangeReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectChangeRequest_ProjectChangeReason_ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "ProjectChangeReasonId",
                principalSchema: "ProjectChangeReasons",
                principalTable: "ProjectChangeReason",
                principalColumn: "ID");
        }
    }
}
