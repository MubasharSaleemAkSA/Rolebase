using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    public partial class IntialsFkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fid",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_Fid",
                table: "users",
                column: "Fid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Role_Fid",
                table: "users",
                column: "Fid",
                principalTable: "Role",
                principalColumn: "roleid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_Fid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Fid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Fid",
                table: "users");
        }
    }
}
