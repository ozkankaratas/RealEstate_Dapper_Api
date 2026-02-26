using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services.Helpers;
using System.Text.RegularExpressions;

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
            var client = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage = await client.GetAsync("Products/ProductListWithCategory");
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

            var client = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage = await client.GetAsync($"Products/ProductSearchList?searchValue={searchValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultProductWithSearchListDto>());
        }

        [HttpGet("ilan/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            var client = _httpClientFactory.CreateClient("RealEstateApi");

            var responseMessage = await client.GetAsync("Products/GetProductById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(jsonData);
                ViewBag.coverImage = values?.CoverImage ?? "productImages/default.png";
                ViewBag.title1 = values?.Title?.ToString();
                ViewBag.price = values?.Price.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));
                ViewBag.city = values?.CityName;
                ViewBag.district = values?.DistrictName;
                ViewBag.semt = values?.SemtName;
                ViewBag.neighborhood = values?.NeighborhoodName;
                ViewBag.type = values?.Type;
                ViewBag.date = values?.Date;
                ViewBag.description = values?.Description;
                ViewBag.id = values?.ProductID;
                ViewBag.longitude = values?.Longitude;
                ViewBag.latitude = values?.Latitude;
                ViewBag.slugUrl = values?.SlugUrl;
            }

            var responseMessage2 = await client.GetAsync("ProductDetails/GetProductDetailById?id=" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
                ViewBag.productSize = values2?.ProductSize;
                ViewBag.bedroomCount = values2?.BedroomCount;
                ViewBag.bathroomCount = values2?.BathroomCount;
                ViewBag.garageSize = values2?.GarageSize;
                ViewBag.buildYear = values2?.BuildYear;
                ViewBag.roomCount = values2?.RoomCount;
                ViewBag.videoUrl = VideoUrlEmbedHelper.ConvertToEmbedUrl(values2?.VideoUrl ?? string.Empty);
            }
            string generatedSlug = CreateSlug(ViewBag.title1);
            ViewBag.slugUrl = generatedSlug;
            return View();
        }

        private string CreateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            // 1. Tüm harfleri küçült (İngilizce kültürüne göre)
            string slug = title.ToLowerInvariant();

            // 2. Türkçe karakterleri İngilizce karşılıklarıyla değiştir
            slug = slug.Replace("ç", "c")
                       .Replace("ğ", "g")
                       .Replace("ı", "i")
                       .Replace("ö", "o")
                       .Replace("ş", "s")
                       .Replace("ü", "u");

            // 3. Harf, rakam, boşluk ve tire DIŞINDAKİ tüm karakterleri sil (Noktalama işaretleri vb.)
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // 4. Birden fazla boşluğu tek bir tireye çevir
            slug = Regex.Replace(slug, @"\s+", "-").Trim();

            // 5. Yan yana gelmiş birden fazla tire varsa (örn: kelime---kelime) tek tireye düşür
            slug = Regex.Replace(slug, @"-+", "-");

            // 6. Başta veya sonda tire kaldıysa onları temizle
            return slug.Trim('-');
        }
    }
}
