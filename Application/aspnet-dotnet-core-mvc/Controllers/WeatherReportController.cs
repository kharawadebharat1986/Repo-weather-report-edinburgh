using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_dotnet_core_mvc.Controllers
{
    public class WeatherReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}