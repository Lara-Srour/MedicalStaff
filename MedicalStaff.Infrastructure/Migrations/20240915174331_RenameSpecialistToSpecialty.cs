using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalStaff.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameSpecialistToSpecialty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialist",
                table: "Doctors",
                newName: "Specialty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Doctors",
                newName: "Specialist");
        }
    }
}
