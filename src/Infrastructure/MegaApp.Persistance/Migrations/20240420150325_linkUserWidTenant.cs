using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class linkUserWidTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleValue",
                table: "AppUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_TenantId",
                table: "AppUsers",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Tenants_TenantId",
                table: "AppUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Tenants_TenantId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_TenantId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RoleValue",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppUsers");
        }
    }
}
