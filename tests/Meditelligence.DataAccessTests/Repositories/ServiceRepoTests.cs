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
    public class ServiceRepoTests
    {
        [Fact]
        public void CreateService_ServiceIsNull_ThrowsError()
        {
            // Arrange
            var context = GenerateDb("CreateServiceIsNull");
            var repo = new ServiceRepo(context);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.CreateService(null));

        }

        [Fact]
        public void CreateService_ServiceExists_ThrowError()
        {
            // Arrange
            var context = GenerateDb("CreateServiceExists");
            var repo = new ServiceRepo(context);

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => repo.CreateService(new Service() { Name="#1"}));
        }

        [Fact]
        public void CreateService_NewService_AddsToDatabase()
        {
            // Arrange
            var context = GenerateDb("CreateServiceThatDoesntExist");
            var repo = new ServiceRepo(context);

            // Act
            var dbBefore = context.Services.Count();
            repo.CreateService(new Service() { Name = "#3" });
            repo.SaveChanges();
            var dbAfter = context.Services.Count();

            // Assert
            Assert.True(dbBefore + 1 == dbAfter);
            Assert.True(context.Services.Any(s => s.Name == "#3"));
        }

        [Fact]
        public void GetAllServices_WhenCalled_ReturnsListOfServices()
        {
            // Arrange
            var context = GenerateDb("GetAllServices");
            var repo = new ServiceRepo(context);

            // Act
            var result = repo.GetAllServices();

            // Assert
            Assert.NotEmpty(result);
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void GetServiceById_IdExists_ReturnsObject()
        {
            // Arrange
            var context = GenerateDb("GetServiceByIdFound");
            var repo = new ServiceRepo(context);

            // Act
            var result = repo.GetServiceById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ServiceID);
        }

        [Fact]
        public void GetServiceById_IdDoesNotExist_ReturnsNull()
        {
            // Arrange
            var context = GenerateDb("GetServiceByIdNotFound");
            var repo = new ServiceRepo(context);

            // Act
            var result = repo.GetServiceById(5678);

            // Assert
            Assert.Null(result);
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.Services.AddRange(new Service
            {
                ServiceID = 1,
                Description = "test service #1",
                Name = "#1"
            },
            new Service
            {
                ServiceID = 2,
                Description = "test service #2",
                Name = "#2"
            });
            context.SaveChanges();

            return context;
        }
    }
}
