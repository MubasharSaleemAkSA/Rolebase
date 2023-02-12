using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class datatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Rolesroleid",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Rolesroleid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rolesroleid",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "URid",
                table: "users",
                newName: "FRid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_users_FRid",
                table: "users",
                column: "FRid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Role_FRid",
                table: "users",
                column: "FRid",
                principalTable: "Role",
                principalColumn: "roleid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_FRid",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_FRid",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "FRid",
                table: "Users",
                newName: "URid");

            migrationBuilder.AddColumn<int>(
                name: "Rolesroleid",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Rolesroleid",
                table: "Users",
                column: "Rolesroleid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Rolesroleid",
                table: "Users",
                column: "Rolesroleid",
                principalTable: "Role",
                principalColumn: "roleid");
        }
    }
}
