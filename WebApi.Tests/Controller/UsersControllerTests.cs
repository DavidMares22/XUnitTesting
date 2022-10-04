using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Tests.Controller
{
    public class UsersControllerTests
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersControllerTests()
        {
            _userService = A.Fake<IUserService>();       
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void UsersController_GetAll_ReturnOk()
        {
            //Arrange
            var users = A.Fake<ICollection<User>>();            
            var controller = new UsersController(_userService, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }

}
