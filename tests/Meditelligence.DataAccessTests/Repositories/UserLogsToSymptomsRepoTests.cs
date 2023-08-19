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
    public class UserLogsToSymptomsRepoTests
    {
        private Mock<ILogger<UserLogsToSymptomsRepo>> _logger = new();
        [Fact]
        public void CreateUserLogToSymptom_UserLogIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("UserLogIDNotFound");
            var repo = new UserLogsToSymptomsRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateUserLogToSymptom(4, 1));

        }

        [Fact]
        public void CreateUserLogToSymptom_SymptomIDNotFound_ThrowsException()
        {
            // arrange
            var context = GenerateDb("symptomIDNotFoundUserLog");
            var repo = new UserLogsToSymptomsRepo(context, _logger.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => repo.CreateUserLogToSymptom(1, 4));
        }

        [Fact]
        public void CreateUserLogToSymptom_RecordAlreadyExists_NoRecordAdded()
        {
            // arrange
            var context = GenerateDb("RecordExistsNoRecordUserLog");
            var repo = new UserLogsToSymptomsRepo(context, _logger.Object);

            // act 
            var before = context.UserLogToSymptoms.Count();
            repo.CreateUserLogToSymptom(1, 1);
            var after = context.UserLogToSymptoms.Count();

            // assert
            Assert.Equal(before, after);
        }

        [Fact]
        public void CreateUserLogToSymptom_SuccessfulInput_AddsNewRecord()
        {
            // arrange
            var context = GenerateDb("successfulResultRecordAddedUserLog");
            var repo = new UserLogsToSymptomsRepo(context, _logger.Object);

            // act 
            var before = context.UserLogToSymptoms.Count();
            repo.CreateUserLogToSymptom(1, 2);
            repo.SaveChanges();
            var after = context.UserLogToSymptoms.Count();

            // assert
            Assert.Equal(before + 1, after);
            Assert.NotNull(context.UserLogToSymptoms.Find(1, 2));
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.UserLogs.Add(new History()
            {
                LogID = 1,
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
            context.UserLogToSymptoms.Add(new HistorySymptom()
            {
                RefLogID = 1,
                RefSymptomID = 1,
            });
            context.SaveChanges();

            return context;
        }
    }
}
