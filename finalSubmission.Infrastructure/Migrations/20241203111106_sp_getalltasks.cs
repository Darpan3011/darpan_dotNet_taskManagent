using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalSubmission.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sp_getalltasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetAllTasks
                AS
                BEGIN
                    SELECT * FROM AllTasksTable;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS GetAllTasks;
            ");

        }
    }
}
