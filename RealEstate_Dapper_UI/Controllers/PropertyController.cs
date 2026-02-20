using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services.Helpers;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertyListWithSearch(string? searchValue, int propertyCategoryId, string city)
        {
            ViewBag.searchValue = searchValue;
            ViewBag.propertyCategoryId = propertyCategoryId;
            ViewBag.city = city;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Products/ProductSearchList?searchValue={searchValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultProductWithSearchListDto>());
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 6;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/GetProductById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                ViewBag.title1 = values.Title.ToString();
                ViewBag.price = values.Price.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));
                ViewBag.city = values.City;
                ViewBag.district = values.District;
                ViewBag.semt = values.Semt;
                ViewBag.neighborhood = values.Neighborhood;
                ViewBag.type = values.Type;
                ViewBag.date = values.Date;
                ViewBag.description = values.Description;
                ViewBag.id = values.ProductID;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:44338/api/ProductDetails/GetProductDetailById?id=" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
                ViewBag.productSize = values2.ProductSize;
                ViewBag.bedroomCount = values2.BedroomCount;
                ViewBag.bathroomCount = values2.BathroomCount;
                ViewBag.garageSize = values2.GarageSize;
                ViewBag.buildYear = values2.BuildYear;
                ViewBag.roomCount = values2.RoomCount;
                ViewBag.videoUrl = VideoUrlEmbedHelper.ConvertToEmbedUrl(values2.VideoUrl);
            }
            return View();
        }
    }
}
