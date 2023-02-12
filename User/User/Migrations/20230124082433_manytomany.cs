using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    activityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activityname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.activityid);
                });

            migrationBuilder.CreateTable(
                name: "RoleActivity",
                columns: table => new
                {
                    RAid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activityid = table.Column<int>(type: "int", nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActivity", x => x.RAid);
                    table.ForeignKey(
                        name: "FK_RoleActivity_Activities_activityid",
                        column: x => x.activityid,
                        principalTable: "Activities",
                        principalColumn: "activityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActivity_Role_roleid",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleActivity_activityid",
                table: "RoleActivity",
                column: "activityid");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActivity_roleid",
                table: "RoleActivity",
                column: "roleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActivity");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
