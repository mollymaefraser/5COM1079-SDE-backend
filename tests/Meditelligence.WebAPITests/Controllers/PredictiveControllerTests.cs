using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Meditelligence.WebAPI.Controllers;
using Meditelligence.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Meditelligence.WebAPITests.Controllers
{
    public class PredictiveControllerTests
    {
        [Fact]
        public void PredictiveDiagnosis_NullSymptomsProvided_ReturnsBadRequest()
        {
            // Arrange
            var context = GenerateDb("NullSymptoms");
            var predictionService = new Mock<IDiseasePredictionService>();

            var controller = new PredictionController(context, predictionService.Object);

            // Act
            var result = controller.PredictiveDiagnosis(null);

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Contains("provide at least 3 symptoms", (string)response.Value);

        }

        [Fact]
        public void PredictiveDiagnosis_LessThan3SymptomsProvided_ReturnsBadRequest()
        {
            // Arrange
            var context = GenerateDb("NullSymptoms");
            var predictionService = new Mock<IDiseasePredictionService>();

            var controller = new PredictionController(context, predictionService.Object);

            // Act
            var result = controller.PredictiveDiagnosis(new List<string> { "" });

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Contains("provide at least 3 symptoms", (string)response.Value);

        }

        [Fact]
        public void PredictiveDiagnosis_PredictiveSuccess_ReturnsOkResult()
        {
            // Arrange
            var context = GenerateDb("NullSymptoms");
            var predictionService = new Mock<IDiseasePredictionService>();
            predictionService.Setup(r => r.Predict(It.IsAny<List<string>>())).Returns(new List<PredictionReadDto>()
            {
                new PredictionReadDto(),
            });

            var controller = new PredictionController(context, predictionService.Object);

            // Act
            var result = controller.PredictiveDiagnosis(new List<string> { "", "", "" });

            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.NotEmpty((List<PredictionReadDto>)response.Value);

        }

        [Fact]
        public void PredictiveDiagnosis_ExceptionThrown_ReturnsBadResult()
        {
            // Arrange
            var context = GenerateDb("NullSymptoms");
            var predictionService = new Mock<IDiseasePredictionService>();
            predictionService.Setup(r => r.Predict(It.IsAny<List<string>>())).Throws<Exception>(() => new Exception("exception"));

            var controller = new PredictionController(context, predictionService.Object);

            // Act
            var result = controller.PredictiveDiagnosis(new List<string> { "", "", "" });

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.Equal("exception", (string)response.Value);

        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);

            return context;
        }
    }
}
