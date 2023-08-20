using AutoMapper;
using Castle.Core.Logging;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Meditelligence.WebAPI.Controllers;
using Meditelligence.WebAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class LocationControllerTests
    {
        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.AddProfile<MeditelligenceProfile>();
        });

        private readonly Mock<ILogger<LocationController>> logger = new ();

        [Fact]
        public void GetAllLocations_WhenCalled_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            mockRepo.Setup(r => r.GetAllLocations()).Returns(new List<Location>()
            {
                new Location(),
            });
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.GetAllLocations();
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.NotEmpty((IEnumerable<LocationReadDto>)response.Value);
        }

        [Fact]
        public void GetLocationById_IdFound_ReturnsRecord()
        {
            // Arrange
            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            mockRepo.Setup(r => r.GetLocationById(1)).Returns(new Location());
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.GetLocationById(1);
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull((LocationReadDto)response.Value);
        }

        [Fact]
        public void GetLocationById_IdNotFound_ReturnsBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            mockRepo.Setup(r => r.GetLocationById(It.IsAny<int>())).Returns((Location)null);
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.GetLocationById(1);
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Null((LocationReadDto)response.Value);
        }

        [Fact]
        public void CreateLocation_LocationCreated_ReturnsOk()
        {
            // Arrange
            var mockrepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.CreateLocation(new LocationCreateDto());

            var response = result.Result as CreatedAtRouteResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, (int)response.StatusCode);
            Assert.NotNull((LocationReadDto)response.Value);
        }

        [Fact]
        public void CreateLocation_ErrorOccurs_ReturnsBadRequest()
        {
            // Arrange
            var mockrepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            mockrepo.Setup(r => r.CreateLocation(It.IsAny<Location>())).Throws<ArgumentException>(() => new ArgumentException("Exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.CreateLocation(new LocationCreateDto());

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Equal("Exception", (string)response.Value);
        }

        [Fact]
        public void CreateLocationToSymptom_IssueOccurs_ReturnsBadRequest()
        {
            // Arrange
            var mockrepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            joinRepo.Setup(r => r.CreateLocationToService(It.IsAny<int>(), It.IsAny<int>())).Throws<Exception>(() => new Exception("exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.CreateServiceToLocation(0, 0);
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.NotNull((string)response.Value);
            Assert.Equal("exception", (string)response.Value);
        }

        [Fact]
        public void CreateLocationToSymptom_LocationAndServicePassedIn_ReturnsOK()
        {
            // Arrange
            var mockrepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object);

            // Act
            var result = controller.CreateServiceToLocation(0, 0);
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull((string)response.Value);
        }
    }
}
