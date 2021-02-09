using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gramium.Server.data.Migrations
{
    public partial class RemoveProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AspNetUsers");

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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
