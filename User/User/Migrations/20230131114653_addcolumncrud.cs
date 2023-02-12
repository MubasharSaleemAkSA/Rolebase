using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    public partial class addcolumncrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "permission",
                table: "RoleActivity",
                newName: "update");

            migrationBuilder.AddColumn<string>(
                name: "create",
                table: "RoleActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delete",
                table: "RoleActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "read",
                table: "RoleActivity",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create",
                table: "RoleActivity");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "RoleActivity");

            migrationBuilder.DropColumn(
                name: "read",
                table: "RoleActivity");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "RoleActivity",
                newName: "permission");
        }
    }
}
