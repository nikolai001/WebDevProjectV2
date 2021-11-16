using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class CreateTableLicensType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicensTypes",
                columns: table => new
                {
                    LicensTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicensExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicensImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensTypes", x => x.LicensTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicensTypes");
        }
    }
}
