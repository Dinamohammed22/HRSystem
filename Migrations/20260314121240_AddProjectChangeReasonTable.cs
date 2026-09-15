using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectChangeReasonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProjectChangeReasons");

            migrationBuilder.EnsureSchema(
                name: "ProjectChangeRequests");

            migrationBuilder.CreateTable(
                name: "ProjectChangeReason",
                schema: "ProjectChangeReasons",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectChangeReason", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectChangeRequest",
                schema: "ProjectChangeRequests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectChangeReasonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectChangeType = table.Column<int>(type: "int", nullable: false),
                    ProjectChangeImpact = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectChangeRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectChangeRequest_ProjectChangeReason_ProjectChangeReasonId",
                        column: x => x.ProjectChangeReasonId,
                        principalSchema: "ProjectChangeReasons",
                        principalTable: "ProjectChangeReason",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeRequest_ProjectChangeReasonId",
                schema: "ProjectChangeRequests",
                table: "ProjectChangeRequest",
                column: "ProjectChangeReasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectChangeRequest",
                schema: "ProjectChangeRequests");

            migrationBuilder.DropTable(
                name: "ProjectChangeReason",
                schema: "ProjectChangeReasons");
        }
    }
}
