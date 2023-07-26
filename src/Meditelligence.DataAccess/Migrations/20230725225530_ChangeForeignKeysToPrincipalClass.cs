using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meditelligence.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeysToPrincipalClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IllnessToSymptoms_Illnesses_IllnessID",
                table: "IllnessToSymptoms");

            migrationBuilder.DropForeignKey(
                name: "FK_IllnessToSymptoms_Symptoms_SymptomID",
                table: "IllnessToSymptoms");

            migrationBuilder.RenameColumn(
                name: "SymptomID",
                table: "IllnessToSymptoms",
                newName: "SymptomRefID");

            migrationBuilder.RenameColumn(
                name: "IllnessID",
                table: "IllnessToSymptoms",
                newName: "IllnessRefID");

            migrationBuilder.RenameIndex(
                name: "IX_IllnessToSymptoms_SymptomID",
                table: "IllnessToSymptoms",
                newName: "IX_IllnessToSymptoms_SymptomRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessToSymptoms_Illnesses_IllnessRefID",
                table: "IllnessToSymptoms",
                column: "IllnessRefID",
                principalTable: "Illnesses",
                principalColumn: "IllnessID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessToSymptoms_Symptoms_SymptomRefID",
                table: "IllnessToSymptoms",
                column: "SymptomRefID",
                principalTable: "Symptoms",
                principalColumn: "SymptomID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IllnessToSymptoms_Illnesses_IllnessRefID",
                table: "IllnessToSymptoms");

            migrationBuilder.DropForeignKey(
                name: "FK_IllnessToSymptoms_Symptoms_SymptomRefID",
                table: "IllnessToSymptoms");

            migrationBuilder.RenameColumn(
                name: "SymptomRefID",
                table: "IllnessToSymptoms",
                newName: "SymptomID");

            migrationBuilder.RenameColumn(
                name: "IllnessRefID",
                table: "IllnessToSymptoms",
                newName: "IllnessID");

            migrationBuilder.RenameIndex(
                name: "IX_IllnessToSymptoms_SymptomRefID",
                table: "IllnessToSymptoms",
                newName: "IX_IllnessToSymptoms_SymptomID");

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessToSymptoms_Illnesses_IllnessID",
                table: "IllnessToSymptoms",
                column: "IllnessID",
                principalTable: "Illnesses",
                principalColumn: "IllnessID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessToSymptoms_Symptoms_SymptomID",
                table: "IllnessToSymptoms",
                column: "SymptomID",
                principalTable: "Symptoms",
                principalColumn: "SymptomID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
