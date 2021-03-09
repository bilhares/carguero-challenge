using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using AddressRegister.Infra.Services;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressRegister.Tests.Tests
{
    public class UserTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperyMock;
        private UserService userService;

        public UserTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperyMock = new Mock<IMapper>();
            userService = new UserService(_userRepositoryMock.Object, _mapperyMock.Object);
        }

        [Theory]
        [InlineData("felipe.bilhares")]
        public async Task SouldNotRegisterAExistingUser(string username)
        {
            _userRepositoryMock.Setup(x => x.FindByUsername(username)).ReturnsAsync(new User(username));
            var userCreated = await userService.Register(new UserDto(username));
            Assert.False(userCreated);
        }

        [Theory]
        [InlineData("random.user.123")]
        public async Task SouldRegisterANewUser(string username)
        {
            var user = new User(username);

            _mapperyMock.Setup(x => x.Map<User>(It.IsAny<UserDto>())).Returns(user);
            _userRepositoryMock.Setup(x => x.Create(user)).ReturnsAsync(user);

            var userCreated = await userService.Register(new UserDto(username));
            Assert.True(userCreated);
        }
    }
}
