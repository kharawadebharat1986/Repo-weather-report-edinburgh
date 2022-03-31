using aspnet_dotnet_core_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_dotnet_core_mvc.Services.Interfaces
{
    public interface IWeatherReportService
    {
        Task<WeatherStackDataModel> GetWeatherReport(string strCity);       
    }
}
