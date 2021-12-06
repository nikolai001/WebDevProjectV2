using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class DeletedLogInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_UserLogin_LoginId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_LicensTypes_DriverLicensTypes_DriverLicensTypeId",
                table: "LicensTypes");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_LicensTypes_DriverLicensTypeId",
                table: "LicensTypes");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LoginId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverLicensTypeId",
                table: "LicensTypes");

            migrationBuilder.DropColumn(
                name: "DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicensTypes_DriverId",
                table: "DriverLicensTypes",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicensTypes_LicensTypeId",
                table: "DriverLicensTypes",
                column: "LicensTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicensTypes_Drivers_DriverId",
                table: "DriverLicensTypes",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicensTypes_LicensTypes_LicensTypeId",
                table: "DriverLicensTypes",
                column: "LicensTypeId",
                principalTable: "LicensTypes",
                principalColumn: "LicensTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicensTypes_Drivers_DriverId",
                table: "DriverLicensTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicensTypes_LicensTypes_LicensTypeId",
                table: "DriverLicensTypes");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicensTypes_DriverId",
                table: "DriverLicensTypes");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicensTypes_LicensTypeId",
                table: "DriverLicensTypes");

            migrationBuilder.AddColumn<int>(
                name: "DriverLicensTypeId",
                table: "LicensTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.LoginId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicensTypes_DriverLicensTypeId",
                table: "LicensTypes",
                column: "DriverLicensTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypesDriverLicensTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LoginId",
                table: "Drivers",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypesDriverLicensTypeId",
                principalTable: "DriverLicensTypes",
                principalColumn: "DriverLicensTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_UserLogin_LoginId",
                table: "Drivers",
                column: "LoginId",
                principalTable: "UserLogin",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicensTypes_DriverLicensTypes_DriverLicensTypeId",
                table: "LicensTypes",
                column: "DriverLicensTypeId",
                principalTable: "DriverLicensTypes",
                principalColumn: "DriverLicensTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
