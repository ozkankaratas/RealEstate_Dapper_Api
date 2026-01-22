using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            //_loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var id = _loginService.GetUserId;

            #region Statictics1 - ProductCount
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44338/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonString1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonString1;
            #endregion

            #region Statictics2 - ProductCountByEmployee
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=1");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployee = jsonString2;
            #endregion

            #region Statictics3 - ActiveProductCountByEmployee
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44338/api/EstateAgentDashboardStatistic/ActiveProductCount?id=1");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ActiveProductCountByEmployee = jsonString3;
            #endregion

            #region Statictics4 - PassiveProductCountByEmployee
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44338/api/EstateAgentDashboardStatistic/PassiveProductCount?id=1");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.PassiveProductCountByEmployee = jsonString4;
            #endregion

            return View();
        }
    }
}
