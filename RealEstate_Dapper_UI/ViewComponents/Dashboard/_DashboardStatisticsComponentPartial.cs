using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Statictics1 - ProductCount
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44338/api/Statistics/ProductCount");
            var jsonString1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonString1;
            #endregion

            #region Statictics2 - EmployeeNameWithMaxProductCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Statistics/EmployeeNameWithMaxProductCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameWithMaxProductCount = jsonString2;
            #endregion

            #region Statictics3 - CityCount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44338/api/Statistics/CityCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.CityCount = jsonString3;
            #endregion

            #region Statictics4 - AverageProductPriceByRent
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44338/api/Statistics/AverageProductPriceByRent");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();

            if (decimal.TryParse(jsonString4, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal avgRentPrice))
            {
                ViewBag.AverageProductPriceByRent = avgRentPrice.ToString("N0");
            }
            else
            {
                ViewBag.AverageProductPriceByRent = "0,00";
            }
            #endregion

            return View();
        }
    }
}
