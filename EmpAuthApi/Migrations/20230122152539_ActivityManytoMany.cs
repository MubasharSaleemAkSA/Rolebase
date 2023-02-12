using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class ActivityManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    activityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activityname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.activityid);
                });

            migrationBuilder.CreateTable(
                name: "Activityrole",
                columns: table => new
                {
                    activityid = table.Column<int>(type: "int", nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activityrole", x => new { x.roleid, x.activityid });
                    table.ForeignKey(
                        name: "FK_Activityrole_Activity_activityid",
                        column: x => x.activityid,
                        principalTable: "Activity",
                        principalColumn: "activityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activityrole_Roles_roleid",
                        column: x => x.roleid,
                        principalTable: "Roles",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activityrole_activityid",
                table: "Activityrole",
                column: "activityid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activityrole");

            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
