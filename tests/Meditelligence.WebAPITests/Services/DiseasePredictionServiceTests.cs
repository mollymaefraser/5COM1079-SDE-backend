using AutoMapper;
using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Meditelligence.WebAPI.Profiles;
using Meditelligence.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Meditelligence.WebAPITests.Services
{
    public class DiseasePredictionServiceTests
    {
        private Mock<ILogger<DiseasePredictionService>> logger = new();

        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.AddProfile<MeditelligenceProfile>();
        });

        [Fact]
        public void Predict_GivenListOfSymptoms_ReturnIllnessWithMostSymptomsMatched()
        {
            // Arrange
            var context = GenerateDb("PredictListOfSymptoms");
            var service = new DiseasePredictionService(logger.Object, context, config.CreateMapper());

            // Act
            var result = service.Predict(new List<string> { "symptom1", "symptom2", "symptom3" });

            // Assert
            Assert.True(result.Count() == 2);
            Assert.Equal("test1", result[0].Illness.IllnessName);
            Assert.Equal("test2", result[1].Illness.IllnessName);
        }

        [Fact]
        public void Predict_NoIllnessFound_ThrowsException()
        {
            // Arrange
            var context = GenerateDb("PredictThrowException");
            var service = new DiseasePredictionService(logger.Object, context, config.CreateMapper());

            // Act & Assert
            Assert.Throws<Exception>(() => service.Predict(new List<string> { "a", "b", "c" }));
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
                Advice = "advice"
            },
            new Illness
            {
                IllnessID = 3,
                Name = "test3",
                Description = "description",
                Advice = "advice"
            });
            context.Symptoms.AddRange(new Symptom
            {
                SymptomID = 1,
                Name = "symptom1"
            },
            new Symptom
            {
                SymptomID = 2,
                Name = "symptom2"
            },
            new Symptom
            {
                SymptomID = 3,
                Name = "symptom3"
            },
            new Symptom
            {
                SymptomID = 4,
                Name = "symptom4"
            });
            context.IllnessToSymptoms.AddRange(new IllnessToSymptom
            {
                IllnessRefID = 1,
                SymptomRefID = 1
            },
            new IllnessToSymptom
            {
                IllnessRefID = 1,
                SymptomRefID = 2
            },
            new IllnessToSymptom
            {
                IllnessRefID = 1,
                SymptomRefID = 3
            },
            new IllnessToSymptom
            {
                IllnessRefID = 2,
                SymptomRefID = 1
            },
            new IllnessToSymptom
            {
                IllnessRefID = 3,
                SymptomRefID = 4
            });

            context.SaveChanges();

            return context;
        }
    }
}
