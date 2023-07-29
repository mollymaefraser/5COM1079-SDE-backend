using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meditelligence.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationServiceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    NameOfFacility = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "LocationToServices",
                columns: table => new
                {
                    RefLocationID = table.Column<int>(type: "INTEGER", nullable: false),
                    RefServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationToServices", x => new { x.RefLocationID, x.RefServiceID });
                    table.ForeignKey(
                        name: "FK_LocationToServices_Locations_RefLocationID",
                        column: x => x.RefLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationToServices_Services_RefServiceID",
                        column: x => x.RefServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Address", "EmailAddress", "Latitude", "Longitude", "NameOfFacility", "Telephone" },
                values: new object[,]
                {
                    { 1, "11, Ely, England", "ElyHospital@MIC.com", 52.41603480972924, 0.30389581535149041, "Ely East Hospital", "017373432732" },
                    { 2, "Alcester Rd, Stratford-upon-Avon CV37 9DD", "StratfordPractice@MIC.com", 52.195169205297645, -1.7250158764978769, "Stratford Practice", "017373434563" },
                    { 3, "59 Kirby Rd, Leicester LE3 6BD", "KirbyCareLeicester@MIC.com", 52.633896958220689, -1.1555297596794039, "Kirby Care Leicester", "017373437632" },
                    { 4, "37-1 Rosedale Ave, Leicester LE4 7AW", "MeditechOrthoLeicester@MIC.com", 52.655561677473628, -1.1058214758058622, "Meditech Orthopaedics Leicester", "01737368576" },
                    { 5, "Mapperley, Nottingham NG3 6AR", "MediTechNotts@MIC.com", 52.984436846989418, -1.1159675166183596, "Meditech Notts Facility", "017373437656" },
                    { 6, "2 Ellison Pl, Newcastle upon Tyne NE1 8ST", "MediTechNewcastle@MIC.com", 54.977379383321349, -1.6091152090172132, "Meditech Newcastle Hospital", "017373432002" },
                    { 7, "53 Cardigan Ln, Burley, Leeds LS4 2LE", "MediTechLeeds@MIC.com", 53.806123966089132, -1.5704154834281872, "Meditech Leeds Facility", "017373431001" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "GP facilities are available at this location.", "GP" },
                    { 2, "Cosmetic and functional plastic surgeries performed here", "Plastic Surgery" },
                    { 3, "Services related to those of cardiovascular conditions", "Cardiology" },
                    { 4, "Urgent services for accidents and emergencies", "A&E" },
                    { 5, "MSK services for issues relating to muscular and skeletel co-ordination", "Physiotherapy" }
                });

            migrationBuilder.InsertData(
                table: "LocationToServices",
                columns: new[] { "RefLocationID", "RefServiceID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 5, 5 },
                    { 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationToServices_RefServiceID",
                table: "LocationToServices",
                column: "RefServiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationToServices");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
