using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalSubmission.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllTasksTable_AllUsersTable_UserId",
                table: "AllTasksTable");

            migrationBuilder.DropIndex(
                name: "IX_AllTasksTable_UserId",
                table: "AllTasksTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AllTasksTable_UserId",
                table: "AllTasksTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllTasksTable_AllUsersTable_UserId",
                table: "AllTasksTable",
                column: "UserId",
                principalTable: "AllUsersTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
