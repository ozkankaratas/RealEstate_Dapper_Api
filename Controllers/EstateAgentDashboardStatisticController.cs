using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticsRepository;
        public EstateAgentDashboardStatisticController(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            var value = _statisticsRepository.AllProductCount();
            return Ok(value);
        }

        [HttpGet("ActiveProductCount")]
        public IActionResult ActiveProductCount(int id)
        {
            var value = _statisticsRepository.ActiveProductCount(id);
            return Ok(value);
        }

        [HttpGet("PassiveProductCount")]
        public IActionResult PassiveProductCount(int id)
        {
            var value = _statisticsRepository.PassiveProductCount(id);
            return Ok(value);
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            var value = _statisticsRepository.ProductCountByEmployeeId(id);
            return Ok(value);
        }


    }
}
