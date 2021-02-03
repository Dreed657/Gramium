using Microsoft.EntityFrameworkCore.Migrations;

namespace Gramium.Server.data.Migrations
{
    public partial class UserModelRefactorings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileuserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileuserId",
                table: "AspNetUsers",
                column: "ProfileuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileuserId",
                table: "AspNetUsers",
                column: "ProfileuserId",
                principalTable: "Profiles",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileuserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileuserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileuserId",
                table: "AspNetUsers");
        }
    }
}
