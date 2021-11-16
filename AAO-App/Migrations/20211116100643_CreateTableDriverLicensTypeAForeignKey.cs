using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class CreateTableDriverLicensTypeAForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverLicensTypes",
                columns: table => new
                {
                    DriverLicensTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    LicensTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicensTypes", x => x.DriverLicensTypeId);
                    table.ForeignKey(
                        name: "FK_DriverLicensTypes_LicensTypes_LicensTypeId",
                        column: x => x.LicensTypeId,
                        principalTable: "LicensTypes",
                        principalColumn: "LicensTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicensTypes_LicensTypeId",
                table: "DriverLicensTypes",
                column: "LicensTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverLicensTypes");
        }
    }
}
