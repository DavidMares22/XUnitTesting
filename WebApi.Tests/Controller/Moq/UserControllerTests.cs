using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Tests.Controller.Moq
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IMapper> _mapper;

        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void UsersController_GetAll_ReturnOk()
        {
            //Arrange
            var users = Mock.Of<List<User>>();
            var controller = new UsersController(_userService.Object, _mapper.Object);

            //Act
            var result = controller.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        
        }
    }
}
