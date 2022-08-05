using AuthorizationMicroservice.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using AuthorizationMicroservice.Controllers;
using AuthorizationMicroservice.Models;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using AuthorizationMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationMicroserviceUnitTest.AuthControllerTest
{


    class WhenAuthControllerUsed
    {
      

        LoginModel loginModel = new LoginModel();

        

        [SetUp]
        public void Setup()
        {
            loginModel = new LoginModel { aadharno = 1234, Password = "1234" };
        }

        [Test]
        public void LoginTest_ValidInput()
        {
             Mock<IRepo> mockirepo = new Mock<IRepo>();

            mockirepo.Setup(s => s.getuserByAadhar(loginModel)).Returns(loginModel);
            AuthController authController = new AuthController(mockirepo.Object);

            var result = authController.Login(loginModel) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void LoginTest_InValidInput()
        {
            Mock<IRepo> mockirepo = new Mock<IRepo>();

            mockirepo.Setup(s => s.getuserByAadhar(loginModel)).Returns(null);
            AuthController authController = new AuthController(mockirepo.Object);

            var result = authController.Login(loginModel) as UnauthorizedResult;
            Assert.That(result.StatusCode, Is.EqualTo(401));
        }

       
    }
}
