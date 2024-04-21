using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class tableNameUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddresses_Tenant_ParentId",
                table: "AppAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantHostels_Tenant_TenantId",
                table: "TenantHostels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddresses_Tenants_ParentId",
                table: "AppAddresses",
                column: "ParentId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantHostels_Tenants_TenantId",
                table: "TenantHostels",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddresses_Tenants_ParentId",
                table: "AppAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantHostels_Tenants_TenantId",
                table: "TenantHostels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddresses_Tenant_ParentId",
                table: "AppAddresses",
                column: "ParentId",
                principalTable: "Tenant",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantHostels_Tenant_TenantId",
                table: "TenantHostels",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");
        }
    }
}
