using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class Updateactivityrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activityrole",
                table: "Activityrole");

            migrationBuilder.AddColumn<int>(
                name: "acid",
                table: "Activityrole",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activityrole",
                table: "Activityrole",
                column: "acid");

            migrationBuilder.CreateIndex(
                name: "IX_Activityrole_roleid",
                table: "Activityrole",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activityrole",
                table: "Activityrole");

            migrationBuilder.DropIndex(
                name: "IX_Activityrole_roleid",
                table: "Activityrole");

            migrationBuilder.DropColumn(
                name: "acid",
                table: "Activityrole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activityrole",
                table: "Activityrole",
                columns: new[] { "roleid", "activityid" });
        }
    }
}
