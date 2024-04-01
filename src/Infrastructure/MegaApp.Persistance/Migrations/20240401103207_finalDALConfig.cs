using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class finalDALConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddresses_Tenants_ParentId",
                table: "AppAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_HostelRoom_TenantHostels_TenantHostelId",
                table: "HostelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOccupants_HostelRoom_HostelRoomId",
                table: "RoomOccupants");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantHostels_Tenants_TenantId",
                table: "TenantHostels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HostelRoom",
                table: "HostelRoom");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.RenameTable(
                name: "HostelRoom",
                newName: "HostelRooms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TenantHostels",
                newName: "TenantHostelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TenantHostelEmployees",
                newName: "TenantHostelEmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RoomOccupants",
                newName: "RoomOccupantId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LeaveTypes",
                newName: "LeaveTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tenant",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HostelRooms",
                newName: "HostelRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HostelRoom_TenantHostelId",
                table: "HostelRooms",
                newName: "IX_HostelRooms_TenantHostelId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AppUsers",
                type: "TEXT",
                nullable: false,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HostelRooms",
                table: "HostelRooms",
                column: "HostelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddresses_Tenant_ParentId",
                table: "AppAddresses",
                column: "ParentId",
                principalTable: "Tenant",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostelRooms_TenantHostels_TenantHostelId",
                table: "HostelRooms",
                column: "TenantHostelId",
                principalTable: "TenantHostels",
                principalColumn: "TenantHostelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOccupants_HostelRooms_HostelRoomId",
                table: "RoomOccupants",
                column: "HostelRoomId",
                principalTable: "HostelRooms",
                principalColumn: "HostelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantHostels_Tenant_TenantId",
                table: "TenantHostels",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddresses_Tenant_ParentId",
                table: "AppAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_HostelRooms_TenantHostels_TenantHostelId",
                table: "HostelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOccupants_HostelRooms_HostelRoomId",
                table: "RoomOccupants");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantHostels_Tenant_TenantId",
                table: "TenantHostels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HostelRooms",
                table: "HostelRooms");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "HostelRooms",
                newName: "HostelRoom");

            migrationBuilder.RenameColumn(
                name: "TenantHostelId",
                table: "TenantHostels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TenantHostelEmployeeId",
                table: "TenantHostelEmployees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoomOccupantId",
                table: "RoomOccupants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeaveTypeId",
                table: "LeaveTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AppUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Tenants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HostelRoomId",
                table: "HostelRoom",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HostelRooms_TenantHostelId",
                table: "HostelRoom",
                newName: "IX_HostelRoom_TenantHostelId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AppUsers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HostelRoom",
                table: "HostelRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddresses_Tenants_ParentId",
                table: "AppAddresses",
                column: "ParentId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostelRoom_TenantHostels_TenantHostelId",
                table: "HostelRoom",
                column: "TenantHostelId",
                principalTable: "TenantHostels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOccupants_HostelRoom_HostelRoomId",
                table: "RoomOccupants",
                column: "HostelRoomId",
                principalTable: "HostelRoom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantHostels_Tenants_TenantId",
                table: "TenantHostels",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
