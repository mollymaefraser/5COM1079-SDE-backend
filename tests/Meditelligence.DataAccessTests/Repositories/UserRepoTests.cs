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
    public class UserRepoTests
    {
        [Fact]
        public void CreateUser_UserIsNull_ThrowsException()
        {
            // Arrange
            var context = GenerateDb("CreateUserNull");
            var repo = new UserRepo(context);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.CreateUser(null));
        }

        [Fact]
        public void CreateUser_UserWithEmailExists_ThrowsException()
        {
            // Arrange
            var context = GenerateDb("CreateUserEmailExists");
            var repo = new UserRepo(context);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repo.CreateUser(new User() { Email="test"}));
        }

        [Fact]
        public void CreateUser_UserDoesntExist_AddsToDb()
        {
            // Arrange
            var context = GenerateDb("CreateUserNewUser");
            var repo = new UserRepo(context);

            // Act 
            var dbBefore = context.Users.Count();
            repo.CreateUser(new User() { Email = "test3" });
            repo.SaveChanges();
            var dbAfter = context.Users.Count();

            // Assert
            Assert.True(dbBefore + 1 == dbAfter);
            Assert.True(context.Users.Any(u => u.Email == "test3"));
        }

        [Fact]
        public void DeleteUser_WhenCalled_DeletesUserFromDb()
        {
            // Arrange
            var context = GenerateDb("DeleteUser");
            var repo = new UserRepo(context);

            // Act
            var dbBefore = context.Users.Count();
            var record = context.Users.Find(1);
            repo.DeleteUser(record);
            repo.SaveChanges();
            var dbAfter = context.Users.Count();

            // Assert
            Assert.True(dbAfter + 1 == dbBefore);
            Assert.False(context.Users.Any(u => u.UserID == 1));
        }

        [Fact]
        public void GetUserById_UserIdFound_ReturnsObject()
        {
            // Arrange
            var context = GenerateDb("GetUserByIdFound");
            var repo = new UserRepo(context);

            // Act
            var result = repo.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.UserID);
        }

        [Fact]
        public void GetUserById_UserIdNotFound_ReturnsNull()
        {
            // Arrange
            var context = GenerateDb("GetUserByIdNotFound");
            var repo = new UserRepo(context);

            // Act
            var result = repo.GetUserById(1348384);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetUserByEmail_EmailFound_ReturnsObject()
        {
            // Arrange
            var context = GenerateDb("GetUserByEmailFound");
            var repo = new UserRepo(context);

            // Act
            var result = repo.GetUserByEmail("test");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test", result.Email);
        }

        [Fact]
        public void GetUserByEmail_EmailNotFound_ReturnsNull()
        {
            // Arrange
            var context = GenerateDb("GetUserByEmailNotFound");
            var repo = new UserRepo(context);

            // Act
            var result = repo.GetUserByEmail("test4373434634");

            // Assert
            Assert.Null(result);
        }

        private MeditelligenceDBContext GenerateDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeditelligenceDBContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            var seeder = new Mock<IMeditelligenceDBSeeder>();

            var context = new MeditelligenceDBContext(options, seeder.Object);
            context.Users.AddRange(new User
            {
                UserID = 1,
                Email = "test",
            },
            new User
            {
                UserID = 2,
                Email = "test2",
            });
            context.SaveChanges();

            return context;
        }
    }
}
