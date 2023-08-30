using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional


namespace Meditelligence.DataAccess.Migrations
{
    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public partial class IllnessToSymptomMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    IllnessID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Advice = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.IllnessID);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomID);
                });

            migrationBuilder.CreateTable(
                name: "IllnessToSymptoms",
                columns: table => new
                {
                    IllnessID = table.Column<int>(type: "INTEGER", nullable: false),
                    SymptomID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessToSymptoms", x => new { x.IllnessID, x.SymptomID });
                    table.ForeignKey(
                        name: "FK_IllnessToSymptoms_Illnesses_IllnessID",
                        column: x => x.IllnessID,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllnessToSymptoms_Symptoms_SymptomID",
                        column: x => x.SymptomID,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "IllnessID", "Advice", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Speak to your GP for further information regarding this", "This is a test disease that will be later removed", "Test disease 1" },
                    { 2, "Speak to a specialist re. this condition, as it could be severe", "This is another test disease that will be later removed", "Test disease 2" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "SymptomID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "High fever", "Symptom 1" },
                    { 2, "Short bursts of giggling", "Symptom 2" },
                    { 3, "Seeing hallucinations", "Symptom 3" },
                    { 4, "Extreme fits of anger", "Symptom 4" },
                    { 5, "No description", "Symptom 5" }
                });

            migrationBuilder.InsertData(
                table: "IllnessToSymptoms",
                columns: new[] { "IllnessID", "SymptomID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IllnessToSymptoms_SymptomID",
                table: "IllnessToSymptoms",
                column: "SymptomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IllnessToSymptoms");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Symptoms");
        }
    }
}
