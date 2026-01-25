using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;
        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet("GetTopCitiesByProductChart")]
        public async Task<IActionResult> GetTopCitiesByProductChart()
        {
            var result = await _chartRepository.GetTopCitiesByProductChart();
            return Ok(result);
        }

        [HttpGet("EmployeeProductCountByYear")]
        public async Task<IActionResult> EmployeeProductCountByYear(int id)
        {
            var values = await _chartRepository.GetEmployeeProductCountByYearChart(id);
            return Ok(values);
        }
    }
}
