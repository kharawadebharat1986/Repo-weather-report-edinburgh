using aspnet_dotnet_core_mvc.Models;
using aspnet_dotnet_core_mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace aspnet_dotnet_core_mvc.Services
{
    public class WeatherReportService: IWeatherReportService
    {
        public async Task<WeatherStackDataModel> GetWeatherReport(string strCity)
        {            
            using (var httpClient = new HttpClient())
            {
                WeatherStackDataModel weatherStackData;
                using (var response = await httpClient.GetAsync("https://localhost:44356/weatherforecast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    weatherStackData = JsonConvert.DeserializeObject<WeatherStackDataModel>(apiResponse);
                }
                return weatherStackData;
            }            
        }
    }
}
