using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalSubmission.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllUsersTable",
                table: "AllUsersTable");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AllUsersTable",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllUsersTable",
                table: "AllUsersTable",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllUsersTable",
                table: "AllUsersTable");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AllUsersTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllUsersTable",
                table: "AllUsersTable",
                column: "UserId");
        }
    }
}
