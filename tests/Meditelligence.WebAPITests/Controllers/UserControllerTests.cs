using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Meditelligence.WebAPI.Controllers;
using Meditelligence.WebAPI.Profiles;
using Microsoft.AspNetCore.Identity;
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
    public class UserControllerTests
    {
        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.AddProfile<MeditelligenceProfile>();
        });

        [Fact]
        public void GetUserById_RecordFound_ReturnsOk()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.GetUserById(It.IsAny<int>())).Returns(new User());
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.GetUserById(1);
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull((UserReadDto)response.Value);
        }

        [Fact]
        public void GetUserById_UserNotFound_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.GetUserById(It.IsAny<int>())).Returns((User)null);
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.GetUserById(1);
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Null((UserReadDto)response.Value);
        }

        [Fact]
        public void RegisterUser_RegistrationSuccessful_ReturnsCreated()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.RegisterUser(new() { UserEmail = "", UserFirstName = "", UserLastName = "", UserPassword = "" });
            var response = result.Result as CreatedAtRouteResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public void RegisterUser_ErrorOccursDuringRegistration_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.CreateUser(It.IsAny<User>())).Throws<Exception>(() => throw new Exception("exception"));
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.RegisterUser(new() { UserEmail = "", UserFirstName = "", UserLastName = "", UserPassword = "" });
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("exception", (string)response.Value);
        }

        [Fact]
        public void Login_AccountNotFound_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns((User)null);
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.LoginUser(new() { Email = "", Password = "" });
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Email or password incorrect.", (string)response.Value);
        }

        [Fact]
        public void Login_PasswordsDoNotMatch_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns(new User());
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();
            hasher.Setup(h => h.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Failed);

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.LoginUser(new() { Email = "", Password = "" });
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Email or password incorrect.", (string)response.Value);
        }

        [Fact]
        public void Login_DetailsCorrect_ReturnsOk()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns(new User());
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();
            hasher.Setup(h => h.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.LoginUser(new() { Email = "", Password = "" });
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull((UserReadDto)response.Value);
        }

        [Fact]
        public void ChangeUserPassword_PasswordRequestIsNull_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.ChangeUserPassword(null);
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("No new password supplied.", (string)response.Value);
        }

        [Fact]
        public void ChangeUserPassword_ErrorOccursChangingPassword_ReturnsBadRequest()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            repo.Setup(r => r.ChangePassword(It.IsAny<int>(), It.IsAny<string>())).Throws<Exception>(() => throw new Exception("exception"));
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.ChangeUserPassword(new());
            var response = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("exception", (string)response.Value);
        }

        [Fact]
        public void ChangeUserPassword_Success_ReturnsOk()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.ChangeUserPassword(new());
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Password successfully changed.", (string)response.Value);
        }

        [Fact]
        public void DeleteUser_WhenCalled_ReturnsOk()
        {
            // Arrange
            var repo = new Mock<IUserRepo>();
            var mapper = config.CreateMapper();
            var hasher = new Mock<IPasswordHasher<User>>();

            var controller = new UserController(repo.Object, mapper, hasher.Object);

            // Act
            var result = controller.DeleteUser(new());
            var response = result.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Account deleted", (string)response.Value);
        }
    }
}
