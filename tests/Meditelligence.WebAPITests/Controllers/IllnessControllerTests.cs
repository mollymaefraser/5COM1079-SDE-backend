using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Meditelligence.WebAPI.Controllers;
using Meditelligence.WebAPI.Profiles;
using Microsoft.AspNetCore.Builder;
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
    public class IllnessControllerTests
    {
        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.AddProfile<MeditelligenceProfile>();
        });

        [Fact]
        public void GetAllIllnesses_WhenCalled_ReturnsRecords()
        {
            // Arrange
            var mockrepo = new Mock<IIllnessRepo>();
            mockrepo.Setup(r => r.GetAllIllnesses()).Returns(new List<Illness>()
            {
                new Illness
                {
                    IllnessID = 1,
                    Name = "illness1",
                    Advice = "",
                    Description = ""
                }
            });
            IMapper mapper = config.CreateMapper();
            var controller = new IllnessController(mockrepo.Object, mapper);

            // Act
            var result = controller.GetAllIllnesses();

            // Assert
            var objectresult = result.Result as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, (int)objectresult.StatusCode);
            Assert.NotNull(objectresult.Value);
            Assert.NotEmpty((IEnumerable<IllnessReadDto>)objectresult.Value);
        }

        [Fact]
        public void GetIllnessById_IdFound_ReturnsRecord()
        {
            // Arrange
            var mockrepo = new Mock<IIllnessRepo>();
            mockrepo.Setup(r => r.GetIllnessById(It.IsAny<int>())).Returns(new Illness()
            {
                IllnessID = 1,
                Name = "illness1",
                Advice = "",
                Description = ""
            });
            IMapper mapper = config.CreateMapper();
            var controller = new IllnessController(mockrepo.Object, mapper);

            // Act
            var result = controller.GetIllnessById(1);

            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            Assert.NotNull((IllnessReadDto)response.Value);
        }

        [Fact]
        public void GetIllnessById_IdNotFound_ReturnsRecord()
        {
            // Arrange
            var mockrepo = new Mock<IIllnessRepo>();
            mockrepo.Setup(r => r.GetIllnessById(It.IsAny<int>())).Returns((Illness)null);
            IMapper mapper = config.CreateMapper();
            var controller = new IllnessController(mockrepo.Object, mapper);

            // Act
            var result = controller.GetIllnessById(1);

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Null((IllnessReadDto)response.Value);
        }

        [Fact]
        public void CreateIllness_RecordCreated_ReturnsCreatedAtActionStatus()
        {
            // Arrange
            var mockrepo = new Mock<IIllnessRepo>();
            IMapper mapper = config.CreateMapper();
            var controller = new IllnessController(mockrepo.Object, mapper);

            // Act
            var result = controller.CreateIllness(new IllnessCreateDto());

            var response = result.Result as CreatedAtRouteResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, (int)response.StatusCode);
            Assert.NotNull((IllnessReadDto)response.Value);
        }

        [Fact]
        public void CreateIllness_IssueWithCreation_ReturnsBadRequest()
        {
            // Arrange
            var mockrepo = new Mock<IIllnessRepo>();
            mockrepo.Setup(r => r.CreateIllness(It.IsAny<Illness>())).Throws<ArgumentException>(() => new ArgumentException("Exception"));
            IMapper mapper = config.CreateMapper();
            var controller = new IllnessController(mockrepo.Object, mapper);

            // Act
            var result = controller.CreateIllness(new IllnessCreateDto());

            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            Assert.Equal("Exception", (string)response.Value);
        }
    }
}
