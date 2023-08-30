using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccessTests.Repositories
{
    public class LocationRepoTests
    {
        [Fact]
        public void CreateLocation_LocationIsNull_ThrowsException()
        {
            //Arrange
            var context = GenerateDb("CreateNullLocation");
            var repo = new LocationRepo(context);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.CreateLocation(null));
        }

        [Fact]
        public void CreateLocation_LocationAlreadyExists_ThrowsException()
        {
            //Arrange
            var context = GenerateDb("CreateLocationAlreadyExists");
            var repo = new LocationRepo(context);
            var Location = new Location()
            {
                Latitude = 1,
                Longitude = 1
            };

            //Act & Assert
            Assert.Throws<InvalidDataException>(() => repo.CreateLocation(Location));
        }

        [Fact]
        public void CreateLocation_ValidLocation_AddsToDatabase()
        {
            // Arrange
            var context = GenerateDb("CreateValidLocations");
            var repo = new LocationRepo(context);

            // Act
            var dbBefore = context.Locations.Count();
            repo.CreateLocation(new Location()
            {
                Longitude = 3,
                Latitude = 3,
            });
            repo.SaveChanges();
            var dbAfter = context.Locations.Count();

            // Assert
            Assert.True(dbBefore < dbAfter);
        }

        [Fact]
        public void GetAllLocations_LocationsPresent_ReturnsCorrectNumberOfRecords()
        {
            // Arrange
            var context = GenerateDb("GetAllLocations");
            var repo = new LocationRepo(context);

            // Act
            var result = repo.GetAllLocations();

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Count() == context.Locations.Count());
        }

        [Fact]
        public void GetLocationById_LocationFound_ReturnsCorrectId()
        {
            // Arrange
            var context = GenerateDb("GetCorrectLocationById");
            var repo = new LocationRepo(context);

            // Act
            var id = 1;
            var result = repo.GetLocationById(id);

            // Arrange
            Assert.NotNull(result);
            Assert.Equal(id, result.LocationID);
        }

        [Fact]
        public void GetLocationById_LocationNotFound_ReturnsDefaultObject()
        {
            // Arrange
            var context = GenerateDb("GetIncorrectLocationById");
            var repo = new LocationRepo(context);

            // Act
            var id = 8;
            var result = repo.GetLocationById(id);

            // Arrange
            Assert.Null(result);
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.Locations.AddRange(new Location
            {
                LocationID = 1,
                Latitude = 1,
                Longitude = 1,
            },
            new Location
            {
                LocationID = 2,
                Latitude = 2,
                Longitude = 2,
            });
            context.SaveChanges();

            return context;
        }
    }
}
