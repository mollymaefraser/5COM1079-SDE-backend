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

        private List<Location> testLocations = new List<Location>()
        {
            new Location ()
            {
                Latitude = 0,
                Longitude = 0,
                NameOfFacility = "Facility1"
            },
            new Location ()
            {
                Latitude = 1,
                Longitude = 1,
                NameOfFacility = "Facility2"
            },
            new Location ()
            {
                Latitude = 2,
                Longitude = 2,
                NameOfFacility = "Facility3"
            },
            new Location ()
            {
                Latitude = 3,
                Longitude = 3,
                NameOfFacility = "Facility4"
            },
            new Location ()
            {
                Latitude = 4,
                Longitude = 4,
                NameOfFacility = "Facility5"
            }
        };


        [Fact]
        public void GetAllLocations_WhenCalled_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            var serviceRepo = new Mock<IServiceRepo>();
            joinRepo.Setup(r => r.GetLocationToServiceByLocationID(It.IsAny<int>())).Returns(new List<LocationToService>() { new LocationToService() });
            serviceRepo.Setup(r => r.GetServiceById(It.IsAny<int>())).Returns(new Service());
            mockRepo.Setup(r => r.GetAllLocations()).Returns(new List<Location>()
            {
                new Location(),
            });
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

            // Act
            var result = controller.GetAllLocations();
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.NotEmpty((IEnumerable<LocationReadDto>)response.Value);
        }

        [Fact]
        public void GetAllLocations_ParametersProvided_ProvidesClosest3()
        {
            // Arrange

            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            var serviceRepo = new Mock<IServiceRepo>();
            joinRepo.Setup(r => r.GetLocationToServiceByLocationID(It.IsAny<int>())).Returns(new List<LocationToService>() { new LocationToService() });
            serviceRepo.Setup(r => r.GetServiceById(It.IsAny<int>())).Returns(new Service());
            mockRepo.Setup(r => r.GetAllLocations()).Returns(testLocations);
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

            // Act
            var result = controller.GetAllLocations(0,0);
            var response = result.Result as OkObjectResult;
            var content = (List<LocationReadDto>)response.Value;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull(response.Value);
            Assert.True(content.Count() == 3);
        }

        [Fact]
        public void GetLocationById_IdFound_ReturnsRecord()
        {
            // Arrange
            var mockRepo = new Mock<ILocationRepo>();
            var joinRepo = new Mock<ILocationToServiceRepo>();
            var serviceRepo = new Mock<IServiceRepo>();
            mockRepo.Setup(r => r.GetLocationById(1)).Returns(new Location());
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

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
            var serviceRepo = new Mock<IServiceRepo>();
            mockRepo.Setup(r => r.GetLocationById(It.IsAny<int>())).Returns((Location)null);
            IMapper mapper = config.CreateMapper();

            var controller = new LocationController(mockRepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

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
            var serviceRepo = new Mock<IServiceRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

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
            var serviceRepo = new Mock<IServiceRepo>();
            mockrepo.Setup(r => r.CreateLocation(It.IsAny<Location>())).Throws<ArgumentException>(() => new ArgumentException("Exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

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
            var serviceRepo = new Mock<IServiceRepo>();
            joinRepo.Setup(r => r.CreateLocationToService(It.IsAny<int>(), It.IsAny<int>())).Throws<Exception>(() => new Exception("exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

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
            var serviceRepo = new Mock<IServiceRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new LocationController(mockrepo.Object, mapper, joinRepo.Object, logger.Object, serviceRepo.Object);

            // Act
            var result = controller.CreateServiceToLocation(0, 0);
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull((string)response.Value);
        }
    }
}
