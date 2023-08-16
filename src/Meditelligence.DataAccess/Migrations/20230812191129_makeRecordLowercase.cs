using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace Meditelligence.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class makeRecordLowercase : Migration
    {
        [ExcludeFromCodeCoverage]
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 1,
                column: "Name",
                value: "test disease 1");

            migrationBuilder.UpdateData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 2,
                column: "Name",
                value: "test disease 2");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 1,
                column: "Name",
                value: "symptom 1");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 2,
                column: "Name",
                value: "symptom 2");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 3,
                column: "Name",
                value: "symptom 3");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 4,
                column: "Name",
                value: "symptom 4");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 5,
                column: "Name",
                value: "symptom 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 1,
                column: "Name",
                value: "Test disease 1");

            migrationBuilder.UpdateData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 2,
                column: "Name",
                value: "Test disease 2");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 1,
                column: "Name",
                value: "Symptom 1");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 2,
                column: "Name",
                value: "Symptom 2");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 3,
                column: "Name",
                value: "Symptom 3");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 4,
                column: "Name",
                value: "Symptom 4");

            migrationBuilder.UpdateData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 5,
                column: "Name",
                value: "Symptom 5");
        }
    }
}
