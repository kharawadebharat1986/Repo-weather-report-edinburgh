using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_dotnet_core_mvc.Models;
using aspnet_dotnet_core_mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_dotnet_core_mvc.Controllers
{
    public class WeatherReportController : Controller
    {
        public string City { get; set; }
        private IWeatherReportService _weatherReportService;

        public WeatherReportController(IWeatherReportService weatherReport)
        {
            _weatherReportService = weatherReport;        
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WeatherModel model)
        {           
            ViewData["weatherReport"] = _weatherReportService.GetWeatherReport(model.City).Result;
            return View();
        }
    }
}