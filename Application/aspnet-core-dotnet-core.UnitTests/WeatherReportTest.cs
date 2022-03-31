using aspnet_dotnet_core_mvc.Controllers;
using aspnet_dotnet_core_mvc.Models;
using aspnet_dotnet_core_mvc.Services;
using aspnet_dotnet_core_mvc.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.UnitTests
{
    [TestClass]
    public class WeatherReportTest
    {
        [TestMethod]
        public void Return_ViewBag_WeatherReportController_Index()
        {
            // Arrange
            WeatherStackDataModel viewDataWeatherReport;
            var reportModel = new WeatherStackDataModel();
            reportModel.current = new Current();
            reportModel.current.humidity = 60;
            reportModel.current.temperature = 20;
            reportModel.current.visibility = 15;
            reportModel.current.pressure = 40;
            
            reportModel.location = new Location();
            var mockFinancialService = new Mock<IWeatherReportService>();
            // Act
            mockFinancialService.Setup(x => x.GetWeatherReport("Edinburgh").Result).Returns(() => reportModel);
            WeatherReportController weatherService = new WeatherReportController(mockFinancialService.Object);
            var report = weatherService.Index(new WeatherModel() { City = "Edinburgh" });
            if (report != null)
            {
                viewDataWeatherReport = (WeatherStackDataModel)((Microsoft.AspNetCore.Mvc.ViewResult)report).ViewData["weatherReport"];
                // Assert
                Assert.AreEqual(reportModel.current.humidity, viewDataWeatherReport.current.humidity, "Humidity provided is correct.");
                Assert.AreEqual(reportModel.current.pressure, viewDataWeatherReport.current.pressure, "Pressure provided is correct.");
                Assert.AreEqual(reportModel.current.temperature, viewDataWeatherReport.current.temperature, "Temprature provided is correct.");
                Assert.AreEqual(reportModel.current.visibility, viewDataWeatherReport.current.visibility, "Visibility provided is correct.");
            }
        }
        
        [TestMethod]
        public void Return_Json_WeatherReportService_GetWeatherReport()
        {
            // Arrange
            #region MyRegion
            //WeatherStackDataModel viewDataWeatherReport;
            //var reportModel = new WeatherStackDataModel();
            //reportModel.current = new Current();
            //reportModel.current.humidity = 60;
            //reportModel.current.temperature = 20;
            //reportModel.current.visibility = 15;
            //reportModel.current.pressure = 40;

            //reportModel.location = new Location();

            //HttpResponseMessage httpResponse = new HttpResponseMessage();
            //httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            //httpResponse.Content = new StringContent("{'abcd':'xyz'}"); //new ObjectContent<WeatherStackDataModel>(reportModel, new JsonMediaTypeFormatter()); 

            //var mockHttpClientWrapper = new Mock<System.Net.Http.HttpClient>();
            //mockHttpClientWrapper.Setup(t => t.GetAsync("https://localhost:44356/weatherforecast").Result)
            //    .Returns(httpResponse);
            #endregion

            WeatherReportService weatherReport = new WeatherReportService(new System.Net.Http.HttpClient());

            //ACT
            var reportResult = weatherReport.GetWeatherReport("Edinburgh").Result;

            //ASSERT
            Assert.AreEqual("United Kingdom", reportResult.location.country);
        }
    }
}
