using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCategoryCount() 
        {
            var client1 = _httpClientFactory.CreateClient("RealEstateApi");
            var responseMessage1 = await client1.GetAsync("Statistics/CategoryCount");
            var value = await responseMessage1.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("RecieveCategoryCount", value);
        }
    }
}
