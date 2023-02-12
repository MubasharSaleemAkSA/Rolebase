using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class intialtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "Users",
                newName: "Rolesroleid");

            migrationBuilder.RenameColumn(
                name: "Fid",
                table: "Users",
                newName: "URid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleid",
                table: "Users",
                newName: "IX_Users_Rolesroleid");

            migrationBuilder.AddColumn<string>(
                name: "cnic",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "confirmpassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Rolesroleid",
                table: "Users",
                column: "Rolesroleid",
                principalTable: "Role",
                principalColumn: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "cnic",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "confirmpassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "URid",
                table: "Users",
                newName: "Fid");

            migrationBuilder.RenameColumn(
                name: "Rolesroleid",
                table: "Users",
                newName: "roleid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Rolesroleid",
                table: "Users",
                newName: "IX_Users_roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_roleid",
                table: "Users",
                column: "roleid",
                principalTable: "Role",
                principalColumn: "roleid");
        }
    }
}
