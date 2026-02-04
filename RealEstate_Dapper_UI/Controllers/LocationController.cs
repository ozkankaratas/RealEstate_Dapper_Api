using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.LocationDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<JsonResult> GetCities()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Locations/cities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCityDto>>(jsonData);
                return Json(values);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<JsonResult> GetDistricts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Locations/GetDistricts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDistrictDto>>(jsonData);
                return Json(values);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<JsonResult> GetSemts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Locations/GetSemts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSemtDto>>(jsonData);
                return Json(values);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<JsonResult> GetNeighborhoods(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Locations/GetNeighborhoods/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNeighborhoodDto>>(jsonData);
                return Json(values);
            }
            return Json(null);
        }
    }
}
