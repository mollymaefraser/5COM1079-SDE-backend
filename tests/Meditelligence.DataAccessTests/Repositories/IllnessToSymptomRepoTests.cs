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
using Xunit;

namespace Meditelligence.DataAccessTests.Repositories
{
    public class IllnessToSymptomRepoTests
    {
        private Mock<ILogger<IllnessToSymptomRepo>> _logger = new();
        [Fact]
        public void CreateIllnessToSymptom_IllnessIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("illnessIDNotFound");
            var repo = new IllnessToSymptomRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateIllnessToSymptom(4, 1));

        }

        [Fact]
        public void CreateIllnessToSymptom_SymptomIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("symptomIDNotFound");
            var repo = new IllnessToSymptomRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateIllnessToSymptom(1, 4));
        }

        [Fact]
        public void CreateIllnessToSymptom_RecordAlreadyExists_NoRecordAdded()
        {
            // arrange
            var context = GenerateDb("RecordExistsNoRecord");
            var repo = new IllnessToSymptomRepo(context, _logger.Object);

            // act 
            var before = context.IllnessToSymptoms.Count();
            repo.CreateIllnessToSymptom(1, 1);
            var after = context.IllnessToSymptoms.Count();

            // assert
            Assert.Equal(before, after);
        }

        [Fact]
        public void CreateIllnessToSymptom_SuccessfulInput_AddsNewRecord()
        {
            // arrange
            var context = GenerateDb("successfulResultRecordAdded");
            var repo = new IllnessToSymptomRepo(context, _logger.Object);

            // act 
            var before = context.IllnessToSymptoms.Count();
            repo.CreateIllnessToSymptom(1, 2);
            repo.SaveChanges();
            var after = context.IllnessToSymptoms.Count();

            // assert
            Assert.Equal(before + 1, after);
            Assert.NotNull(context.IllnessToSymptoms.Find(1, 2));
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.Illnesses.Add(new Illness()
            {
                IllnessID = 1,
            });
            context.Symptoms.AddRange(new Symptom[]
            {
                new Symptom()
                {
                    SymptomID = 1,
                },
                new Symptom()
                {
                    SymptomID = 2,
                },
            });
            context.IllnessToSymptoms.Add(new IllnessToSymptom()
            {
                IllnessRefID = 1,
                SymptomRefID = 1,
            });
            context.SaveChanges();

            return context;
        }
    }
}
