using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Meditelligence.WebAPI.Controllers;
using Meditelligence.WebAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
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
    public class SymptomControllerTests
    {
        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.AddProfile<MeditelligenceProfile>();
        });

        [Fact]
        public void GetAllSymptoms_WhenCalled_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<ISymptomRepo>();
            mockRepo.Setup(r => r.GetAllSymptoms()).Returns(new List<Symptom>()
            {
                new Symptom(),
            });
            IMapper mapper = config.CreateMapper();

            var controller = new SymptomController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetAllSymptoms();
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.NotEmpty((IEnumerable<SymptomReadDto>)response.Value);
        }

        [Fact]
        public void GetSymptomById_IdFound_ReturnsRecord()
        {
            // Arrange
            var mockRepo = new Mock<ISymptomRepo>();
            mockRepo.Setup(r => r.GetSymptomById(1)).Returns(new Symptom());
            IMapper mapper = config.CreateMapper();

            var controller = new SymptomController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetSymptomById(1);
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull((SymptomReadDto)response.Value);
        }

        [Fact]
        public void GetSymptomById_IdNotFound_ReturnsBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<ISymptomRepo>();
            mockRepo.Setup(r => r.GetSymptomById(It.IsAny<int>())).Returns((Symptom)null);
            IMapper mapper = config.CreateMapper();

            var controller = new SymptomController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetSymptomById(1);
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Null((SymptomReadDto)response.Value);
        }

        [Fact]
        public void CreateSymptom_SymptomCreated_ReturnsOk()
        {
            // Arrange
            var mockrepo = new Mock<ISymptomRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new SymptomController(mockrepo.Object, mapper);

            // Act
            var result = controller.CreateSymptom(new SymptomCreateDto());

            var response = result.Result as CreatedAtRouteResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, (int)response.StatusCode);
            Assert.NotNull((SymptomReadDto)response.Value);
        }

        [Fact]
        public void CreateSymptom_ErrorOccurs_ReturnsBadRequest()
        {
            // Arrange
            var mockrepo = new Mock<ISymptomRepo>();
            mockrepo.Setup(r => r.CreateSymptom(It.IsAny<Symptom>())).Throws<ArgumentException>(() => new ArgumentException("Exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new SymptomController(mockrepo.Object, mapper);

            // Act
            var result = controller.CreateSymptom(new SymptomCreateDto());

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Equal("Exception", (string)response.Value);
        }
    }
}
