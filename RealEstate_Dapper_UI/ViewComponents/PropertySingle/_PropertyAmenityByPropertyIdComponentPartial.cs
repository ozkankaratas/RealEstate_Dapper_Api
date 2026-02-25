using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var client = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage = await client.GetAsync("PropertyAmenities/GetPropertyAmenity?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultPropertyAmenityDto>());
        }
    }
}
