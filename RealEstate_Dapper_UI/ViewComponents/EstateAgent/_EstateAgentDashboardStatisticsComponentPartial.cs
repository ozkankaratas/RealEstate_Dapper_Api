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
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;

            #region Statictics1 - ProductCount
            var client = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage1 = await client.GetAsync("EstateAgentDashboardStatistic/AllProductCount");
            var jsonString1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonString1;
            #endregion

            #region Statictics2 - ProductCountByEmployee
            var responseMessage2 = await client.GetAsync("EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=" + id);
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployee = jsonString2;
            #endregion

            #region Statictics3 - ActiveProductCountByEmployee
            var responseMessage3 = await client.GetAsync("EstateAgentDashboardStatistic/ActiveProductCount?id=" + id);
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ActiveProductCountByEmployee = jsonString3;
            #endregion

            #region Statictics4 - PassiveProductCountByEmployee
            var responseMessage4 = await client.GetAsync("EstateAgentDashboardStatistic/PassiveProductCount?id=" + id);
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.PassiveProductCountByEmployee = jsonString4;
            #endregion

            return View();
        }
    }
}
