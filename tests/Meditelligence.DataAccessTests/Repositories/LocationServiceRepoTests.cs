using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccessTests.Repositories
{
    public class LocationServiceRepoTests
    {
        private Mock<ILogger<LocationToServiceRepo>> _logger = new();
        [Fact]
        public void CreateLocationToService_LocationIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("LocationIDNotFound");
            var repo = new LocationToServiceRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateLocationToService(4, 1));

        }

        [Fact]
        public void CreateLocationToService_ServiceIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("ServiceIDNotFound");
            var repo = new LocationToServiceRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateLocationToService(1, 4));
        }

        [Fact]
        public void CreateLocationToService_RecordAlreadyExists_NoRecordAdded()
        {
            // arrange
            var context = GenerateDb("RecordExistsNoRecord");
            var repo = new LocationToServiceRepo(context, _logger.Object);

            // act 
            var before = context.LocationToServices.Count();
            repo.CreateLocationToService(1, 1);
            var after = context.LocationToServices.Count();

            // assert
            Assert.Equal(before, after);
        }

        [Fact]
        public void CreateLocationToService_SuccessfulInput_AddsNewRecord()
        {
            // arrange
            var context = GenerateDb("successfulResultRecordAdded");
            var repo = new LocationToServiceRepo(context, _logger.Object);

            // act 
            var before = context.LocationToServices.Count();
            repo.CreateLocationToService(1, 2);
            repo.SaveChanges();
            var after = context.LocationToServices.Count();

            // assert
            Assert.Equal(before + 1, after);
            Assert.NotNull(context.LocationToServices.Find(1, 2));
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.Locations.Add(new Location()
            {
                LocationID = 1,
            });
            context.Services.AddRange(new Service[]
            {
                new Service()
                {
                    ServiceID = 1,
                },
                new Service()
                {
                    ServiceID = 2,
                },
            });
            context.LocationToServices.Add(new LocationToService()
            {
                RefLocationID = 1,
                RefServiceID = 1,
            });
            context.SaveChanges();

            return context;
        }
    }
}
