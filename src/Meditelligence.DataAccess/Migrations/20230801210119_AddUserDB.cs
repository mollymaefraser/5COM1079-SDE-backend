using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meditelligence.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class AddUserDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "INTEGER", nullable: false),
                    LogDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PredictedDiagnosisID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_UserLogs_Illnesses_PredictedDiagnosisID",
                        column: x => x.PredictedDiagnosisID,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_LogID",
                        column: x => x.LogID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogToSymptoms",
                columns: table => new
                {
                    RefLogID = table.Column<int>(type: "INTEGER", nullable: false),
                    RefSymptomID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogToSymptoms", x => new { x.RefLogID, x.RefSymptomID });
                    table.ForeignKey(
                        name: "FK_UserLogToSymptoms_Symptoms_RefSymptomID",
                        column: x => x.RefSymptomID,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogToSymptoms_UserLogs_RefLogID",
                        column: x => x.RefLogID,
                        principalTable: "UserLogs",
                        principalColumn: "LogID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "IsAdmin", "LastName", "Password" },
                values: new object[] { 1, "admin@testAdmin.com", "Admin", true, "User", "password" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_PredictedDiagnosisID",
                table: "UserLogs",
                column: "PredictedDiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogToSymptoms_RefSymptomID",
                table: "UserLogToSymptoms",
                column: "RefSymptomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogToSymptoms");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
