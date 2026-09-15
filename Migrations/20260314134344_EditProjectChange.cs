using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditProjectChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeRequest_CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectChangeRequest_Candidate_CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "CandidateId",
                principalSchema: "Candidates",
                principalTable: "Candidate",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectChangeRequest_Candidate_CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeRequest_CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest");
        }
    }
}
