using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Moq;

namespace Meditelligence.DataAccessTests.Repositories
{
    public class IllnessRepoTests
    {
        [Fact]
        public void CreateIllness_IllnessIsNull_ThrowsException()
        {
            // Arrange
            var context = GenerateDb("CreateNullIllness");
            var repo = new IllnessRepo(context);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.CreateIllness(null));
        }

        [Fact]
        public void CreateIllness_IllnessAlreadyExists_ThrowsException()
        {
            // Arrange
            var context = GenerateDb("CreateExistingIllness");
            var repo = new IllnessRepo(context);

            var testIllness = new Illness
            {
                Name = "test1"
            };

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => repo.CreateIllness(testIllness));
        }

        [Fact]
        public void CreateIllness_NewIllnessPassed_AddsRecord()
        {
            // Arrange
            var context = GenerateDb("CreateNewIllness");
            var repo = new IllnessRepo(context);

            // Act
            var dbBefore = context.Illnesses.Count();
            repo.CreateIllness(new Illness()
            {
                Name = "test3",
            });
            repo.SaveChanges();
            var dbAfter = context.Illnesses.Count();

            // Assert
            Assert.True(dbBefore < dbAfter);
        }

        [Fact]
        public void GetAllIllnesses_IllnessesPresent_ReturnsCorrectNumberOfRecords()
        {
            // Arrange
            var context = GenerateDb("GetAllIllnesses");
            var repo = new IllnessRepo(context);

            // Act
            var result = repo.GetAllIllnesses();

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Count() == context.Illnesses.Count());
        }

        [Fact]
        public void GetIllnessById_IllnessFound_ReturnsCorrectId()
        {
            // Arrange
            var context = GenerateDb("GetCorrectIllnessById");
            var repo = new IllnessRepo(context);

            // Act
            var id = 1;
            var result = repo.GetIllnessById(id);

            // Arrange
            Assert.NotNull(result);
            Assert.Equal(id, result.IllnessID);
        }

        [Fact]
        public void GetIllnessById_IllnessNotFound_ReturnsDefaultObject()
        {
            // Arrange
            var context = GenerateDb("GetIncorrectIllnessById");
            var repo = new IllnessRepo(context);

            // Act
            var id = 8;
            var result = repo.GetIllnessById(id);

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
            context.Illnesses.AddRange(new Illness
            {
                IllnessID = 1,
                Name = "test1",
                Description = "description",
                Advice = "advice",
            },
            new Illness
            {
                IllnessID = 2,
                Name = "test2",
                Description = "description",
                Advice = "advice,"
            });
            context.SaveChanges();

            return context;
        }
    }
}