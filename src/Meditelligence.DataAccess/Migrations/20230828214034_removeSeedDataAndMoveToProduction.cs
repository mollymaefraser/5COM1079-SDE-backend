using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meditelligence.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeSeedDataAndMoveToProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_LogID",
                table: "UserLogs");

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "IllnessToSymptoms",
                keyColumns: new[] { "IllnessRefID", "SymptomRefID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "IllnessID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "SymptomID",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "LogID",
                table: "UserLogs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserLogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAENqGbpgd0Zwg2wLBAzfh7t642eDYqjapjx5sAWDI0HoGgRAADq2czAQrYW9qjU3OeQ==");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserID",
                table: "UserLogs",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_UserID",
                table: "UserLogs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_UserID",
                table: "UserLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLogs_UserID",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserLogs");

            migrationBuilder.AlterColumn<int>(
                name: "LogID",
                table: "UserLogs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "IllnessID", "Advice", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Speak to your GP for further information regarding this", "This is a test disease that will be later removed", "test disease 1" },
                    { 2, "Speak to a specialist re. this condition, as it could be severe", "This is another test disease that will be later removed", "test disease 2" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "SymptomID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "High fever", "symptom 1" },
                    { 2, "Short bursts of giggling", "symptom 2" },
                    { 3, "Seeing hallucinations", "symptom 3" },
                    { 4, "Extreme fits of anger", "symptom 4" },
                    { 5, "No description", "symptom 5" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "password");

            migrationBuilder.InsertData(
                table: "IllnessToSymptoms",
                columns: new[] { "IllnessRefID", "SymptomRefID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_LogID",
                table: "UserLogs",
                column: "LogID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
