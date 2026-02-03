using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityByPropertyIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _PropertyAmenityByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            id = 1; // Test amaçlı sabit bir değer atandı
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/PropertyAmenities/GetPropertyAmenity?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
