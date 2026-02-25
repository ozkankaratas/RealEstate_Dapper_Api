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
            var client = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage = await client.GetAsync("Statistics/ActiveCategoryCount");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonString;
            #endregion

            #region Statictics2 - ActiveEmployeeCount
            var responseMessage2 = await client.GetAsync("Statistics/ActiveEmployeeCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonString2;
            #endregion

            #region Statictics3 - ApartmentCount
            var responseMessage3 = await client.GetAsync("Statistics/ApartmentCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonString3;
            #endregion

            #region Statictics4 - AvarageRoomCount
            var responseMessage4 = await client.GetAsync("Statistics/AvarageRoomCount");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.AvarageRoomCount = jsonString4;
            #endregion

            #region Statictics5 - AverageProductPriceByRent
            var responseMessage5 = await client.GetAsync("Statistics/AverageProductPriceByRent");
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
            var responseMessage6 = await client.GetAsync("Statistics/AverageProductPriceBySale");
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
            var responseMessage7 = await client.GetAsync("Statistics/CategoryCount");
            var jsonString7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonString7;
            #endregion

            #region Statictics8 - CategoryNameWithMaxProductCount
            var responseMessage8 = await client.GetAsync("Statistics/CategoryNameWithMaxProductCount");
            var jsonString8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameWithMaxProductCount = jsonString8;
            #endregion

            #region Statictics9 - CityNameWithMaxProductCount
            var responseMessage9 = await client.GetAsync("Statistics/CityNameWithMaxProductCount");
            var jsonString9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameWithMaxProductCount = jsonString9;
            #endregion

            #region Statictics10 - CityCount
            var responseMessage10 = await client.GetAsync("Statistics/CityCount");
            var jsonString10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.CityCount = jsonString10;
            #endregion

            #region Statictics11 - EmployeeNameWithMaxProductCount
            var responseMessage11 = await client.GetAsync("Statistics/EmployeeNameWithMaxProductCount");
            var jsonString11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameWithMaxProductCount = jsonString11;
            #endregion

            #region Statictics12 - LastProductPrice
            var responseMessage12 = await client.GetAsync("Statistics/LastProductPrice");
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
            var responseMessage13 = await client.GetAsync("Statistics/NewestBuildingYear");
            var jsonString13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonString13;
            #endregion

            #region Statictics14 - OldestBuildingYear
            var responseMessage14 = await client.GetAsync("Statistics/OldestBuildingYear");
            var jsonString14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonString14;
            #endregion

            #region Statictics15 - PassiveCategoryCount
            var responseMessage15 = await client.GetAsync("Statistics/PassiveCategoryCount");
            var jsonString15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonString15;
            #endregion

            #region Statictics16 - ProductCount
            var responseMessage16 = await client.GetAsync("Statistics/ProductCount");
            var jsonString16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonString16;
            #endregion
            return View();
        }

        

    }
}
