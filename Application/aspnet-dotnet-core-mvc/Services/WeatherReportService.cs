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
        private HttpClient _httpClient;

        public WeatherReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<WeatherStackDataModel> GetWeatherReport(string strCity)
        {
            WeatherStackDataModel weatherStackData;
            try
            {
                string url = string.Format("{0}?strCity={1}", "https://api-weather-report-edinburgh.azurewebsites.net/weatherforecast", strCity);
                using (var response = await _httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    weatherStackData = JsonConvert.DeserializeObject<WeatherStackDataModel>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                weatherStackData = new WeatherStackDataModel();
                weatherStackData.Error = ex.Message;
            }
            return weatherStackData;
        }
    }
}
