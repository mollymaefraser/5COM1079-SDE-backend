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
    public class SymptomRepoTests
    {
        [Fact]
        public void CreateSymptom_SymptomIsNull_ThrowsException()
        {
            //Arrange
            var context = GenerateDb("CreateNullSymptom");
            var repo = new SymptomRepo(context);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.CreateSymptom(null));
        }

        [Fact]
        public void CreateSymptom_SymptomAlreadyExists_ThrowsException()
        {
            //Arrange
            var context = GenerateDb("CreateSymptomAlreadyExists");
            var repo = new SymptomRepo(context);
            var symptom = new Symptom()
            {
                Name = "symptom1",
            };

            //Act & Assert
            Assert.Throws<InvalidDataException>(() => repo.CreateSymptom(symptom));
        }

        [Fact]
        public void CreateSymptom_ValidSymptom_AddsToDatabase()
        {
            // Arrange
            var context = GenerateDb("CreateValidSymptoms");
            var repo = new SymptomRepo(context);

            // Act
            var dbBefore = context.Symptoms.Count();
            repo.CreateSymptom(new Symptom()
            {
                Name = "symptom3",
            });
            repo.SaveChanges();
            var dbAfter = context.Symptoms.Count();

            // Assert
            Assert.True(dbBefore < dbAfter);
        }

        [Fact]
        public void GetAllSymptoms_SymptomsPresent_ReturnsCorrectNumberOfRecords()
        {
            // Arrange
            var context = GenerateDb("GetAllSymptoms");
            var repo = new SymptomRepo(context);

            // Act
            var result = repo.GetAllSymptoms();

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Count() == context.Symptoms.Count());
        }

        [Fact]
        public void GetSymptomById_SymptomFound_ReturnsCorrectId()
        {
            // Arrange
            var context = GenerateDb("GetCorrectSymptomById");
            var repo = new SymptomRepo(context);

            // Act
            var id = 1;
            var result = repo.GetSymptomById(id);

            // Arrange
            Assert.NotNull(result);
            Assert.Equal(id, result.SymptomID);
        }

        [Fact]
        public void GetSymptomById_SymptomNotFound_ReturnsDefaultObject()
        {
            // Arrange
            var context = GenerateDb("GetIncorrectSymptomById");
            var repo = new SymptomRepo(context);

            // Act
            var id = 8;
            var result = repo.GetSymptomById(id);

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
            context.Symptoms.AddRange(new Symptom
            {
                SymptomID = 1,
                Name = "symptom1",
                Description = "description",
            },
            new Symptom
            {
                SymptomID = 2,
                Name = "symptom2",
                Description = "description",
            });
            context.SaveChanges();

            return context;
        }
    }
}
