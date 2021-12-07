using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class DeletedAvailabilitiTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_AvailabilityTypes_AvailabilityTypeId",
                table: "Availabilities");

            migrationBuilder.DropTable(
                name: "AvailabilityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_AvailabilityTypeId",
                table: "Availabilities");

            migrationBuilder.RenameColumn(
                name: "AvailabilityTypeId",
                table: "Availabilities",
                newName: "AvailabilityType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailabilityType",
                table: "Availabilities",
                newName: "AvailabilityTypeId");

            migrationBuilder.CreateTable(
                name: "AvailabilityTypes",
                columns: table => new
                {
                    AvailabilityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityTypes", x => x.AvailabilityTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_AvailabilityTypeId",
                table: "Availabilities",
                column: "AvailabilityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_AvailabilityTypes_AvailabilityTypeId",
                table: "Availabilities",
                column: "AvailabilityTypeId",
                principalTable: "AvailabilityTypes",
                principalColumn: "AvailabilityTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
