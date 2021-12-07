using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class ChangedeDriverTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_UserLogin_LoginId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LoginId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LicensImage",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Drivers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "LicensImage",
                table: "Drivers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LoginId",
                table: "Drivers",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_UserLogin_LoginId",
                table: "Drivers",
                column: "LoginId",
                principalTable: "UserLogin",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
