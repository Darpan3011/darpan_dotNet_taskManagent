using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalSubmission.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mg_GetAllTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the stored procedure
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetAllTasksProcedure
            AS
            BEGIN
                SELECT Title, Description, UserId, DueDate, Status
                FROM AllTasksTable
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the stored procedure if rolling back
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllTasksProcedure");
        }
    }
}
