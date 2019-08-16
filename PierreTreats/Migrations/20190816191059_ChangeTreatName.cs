using Microsoft.EntityFrameworkCore.Migrations;

namespace PierreTreats.Migrations
{
    public partial class ChangeTreatName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreatName",
                table: "Treats",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Treats",
                newName: "TreatName");
        }
    }
}
