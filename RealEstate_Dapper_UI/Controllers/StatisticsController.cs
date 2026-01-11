using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region Statictics1 - ActiveCategoryCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Statistics/ActiveCategoryCount");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonString;
            #endregion

            #region Statictics2 - ActiveEmployeeCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Statistics/ActiveEmployeeCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonString2;
            #endregion

            #region Statictics3 - ApartmentCount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44338/api/Statistics/ApartmentCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonString3;
            #endregion

            #region Statictics4 - AvarageRoomCount
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44338/api/Statistics/AvarageRoomCount");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.AvarageRoomCount = jsonString4;
            #endregion

            #region Statictics5 - AverageProductPriceByRent
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44338/api/Statistics/AverageProductPriceByRent");
            var jsonString5 = await responseMessage5.Content.ReadAsStringAsync();

            if (decimal.TryParse(jsonString5, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal avgRentPrice))
            {
                ViewBag.AverageProductPriceByRent = avgRentPrice.ToString("N0");
            }
            else
            {
                ViewBag.AverageProductPriceByRent = "0,00";
            }
            #endregion

            #region Statictics6 - AverageProductPriceBySale
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44338/api/Statistics/AverageProductPriceBySale");
            var jsonString6 = await responseMessage6.Content.ReadAsStringAsync();

            if (decimal.TryParse(jsonString6, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal avgSalePrice))
            {
                ViewBag.AverageProductPriceBySale = avgSalePrice.ToString("N0");
            }
            else
            {
                ViewBag.AverageProductPriceBySale = "0,00";
            }
            #endregion

            #region Statictics7 - CategoryCount
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44338/api/Statistics/CategoryCount");
            var jsonString7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonString7;
            #endregion

            #region Statictics8 - CategoryNameWithMaxProductCount
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44338/api/Statistics/CategoryNameWithMaxProductCount");
            var jsonString8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameWithMaxProductCount = jsonString8;
            #endregion

            #region Statictics9 - CityNameWithMaxProductCount
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44338/api/Statistics/CityNameWithMaxProductCount");
            var jsonString9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameWithMaxProductCount = jsonString9;
            #endregion

            #region Statictics10 - CityCount
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44338/api/Statistics/CityCount");
            var jsonString10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.CityCount = jsonString10;
            #endregion

            #region Statictics11 - EmployeeNameWithMaxProductCount
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:44338/api/Statistics/EmployeeNameWithMaxProductCount");
            var jsonString11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameWithMaxProductCount = jsonString11;
            #endregion

            #region Statictics12 - LastProductPrice
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:44338/api/Statistics/LastProductPrice");
            var jsonString12 = await responseMessage12.Content.ReadAsStringAsync();

            if (decimal.TryParse(jsonString12, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal lastPrice))
            {
                ViewBag.LastProductPrice = lastPrice.ToString("N0");
            }
            else
            {
                ViewBag.LastProductPrice = "0,00";
            }
            #endregion

            #region Statictics13 - NewestBuildingYear
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:44338/api/Statistics/NewestBuildingYear");
            var jsonString13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonString13;
            #endregion

            #region Statictics14 - OldestBuildingYear
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:44338/api/Statistics/OldestBuildingYear");
            var jsonString14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonString14;
            #endregion

            #region Statictics15 - PassiveCategoryCount
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44338/api/Statistics/PassiveCategoryCount");
            var jsonString15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonString15;
            #endregion

            #region Statictics16 - ProductCount
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44338/api/Statistics/ProductCount");
            var jsonString16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonString16;
            #endregion
            return View();
        }

        

    }
}
