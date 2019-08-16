using Microsoft.EntityFrameworkCore.Migrations;

namespace PierreTreats.Migrations
{
    public partial class removeVirtualFromFlavorAndTreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlavorTreats_Flavors_FlavorId",
                table: "FlavorTreats");

            migrationBuilder.DropForeignKey(
                name: "FK_FlavorTreats_Treats_TreatId",
                table: "FlavorTreats");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FlavorTreats");

            migrationBuilder.AlterColumn<int>(
                name: "TreatId",
                table: "FlavorTreats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlavorId",
                table: "FlavorTreats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlavorTreats_Flavors_FlavorId",
                table: "FlavorTreats",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlavorTreats_Treats_TreatId",
                table: "FlavorTreats",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlavorTreats_Flavors_FlavorId",
                table: "FlavorTreats");

            migrationBuilder.DropForeignKey(
                name: "FK_FlavorTreats_Treats_TreatId",
                table: "FlavorTreats");

            migrationBuilder.AlterColumn<int>(
                name: "TreatId",
                table: "FlavorTreats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FlavorId",
                table: "FlavorTreats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FlavorTreats",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlavorTreats_Flavors_FlavorId",
                table: "FlavorTreats",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlavorTreats_Treats_TreatId",
                table: "FlavorTreats",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
