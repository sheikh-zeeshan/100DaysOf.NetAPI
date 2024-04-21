using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateHostelSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "TenantHostels",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TenantHostels",
                newName: "IsPaid");
        }
    }
}
