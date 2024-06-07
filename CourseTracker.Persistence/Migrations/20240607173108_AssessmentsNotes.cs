using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentsNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Assessments");
        }
    }
}
