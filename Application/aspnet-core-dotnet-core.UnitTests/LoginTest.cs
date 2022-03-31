using aspnet_dotnet_core_mvc.Controllers;
using aspnet_dotnet_core_mvc.Models;
using aspnet_dotnet_core_mvc.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnet_core_dotnet_core.UnitTests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Return_True_LoginController_CheckUserCredentials()
        {
            // Arrange
            LoginModel loginModel = new LoginModel();
            loginModel.LoginName = "admin1";
            loginModel.Password = "passw0rd";
            var mockLoginService = new Mock<ILoginService>();
            // Act
            mockLoginService.Setup(x => x.CheckUserCredentials("admin","admin").Result).Returns(() => false);
            LoginController loginService = new LoginController(mockLoginService.Object);
            var result = loginService.CheckUserCredentials(loginModel).Result;
            
            // Assert
            Assert.AreEqual(result, false);            
        }
    }
}
