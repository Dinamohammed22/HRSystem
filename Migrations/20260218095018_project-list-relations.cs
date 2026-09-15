using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class projectlistrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask",
                column: "ProjectListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectLists_ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask",
                column: "ProjectListId",
                principalTable: "ProjectLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectLists_ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTask_ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectListId",
                schema: "ProjectTask",
                table: "ProjectTask");
        }
    }
}
