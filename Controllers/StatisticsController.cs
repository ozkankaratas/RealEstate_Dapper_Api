using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var value = _statisticsRepository.ActiveCategoryCount();
            return Ok(value);
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            var value = _statisticsRepository.ActiveEmployeeCount();
            return Ok(value);
        }

        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            var value = _statisticsRepository.ApartmentCount();
            return Ok(value);
        }

        [HttpGet("AvarageRoomCount")]
        public IActionResult AvarageRoomCount()
        {
            var value = _statisticsRepository.AvarageRoomCount();
            return Ok(value);
        }

        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            var value = _statisticsRepository.AverageProductPriceByRent();
            return Ok(value);
        }

        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            var value = _statisticsRepository.AverageProductPriceBySale();
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var value = _statisticsRepository.CategoryCount();
            return Ok(value);
        }

        [HttpGet("CategoryNameWithMaxProductCount")]
        public IActionResult CategoryNameWithMaxProductCount()
        {
            var value = _statisticsRepository.CategoryNameWithMaxProductCount();
            return Ok(value);
        }

        [HttpGet("CityNameWithMaxProductCount")]
        public IActionResult CityNameWithMaxProductCount()
        {
            var value = _statisticsRepository.CityNameWithMaxProductCount();
            return Ok(value);
        }

        [HttpGet("CityCount")]
        public IActionResult CityCount()
        {
            var value = _statisticsRepository.CityCount();
            return Ok(value);
        }

        [HttpGet("EmployeeNameWithMaxProductCount")]
        public IActionResult EmployeeNameWithMaxProductCount()
        {
            var value = _statisticsRepository.EmployeeNameWithMaxProductCount();
            return Ok(value);
        }

        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            var value = _statisticsRepository.LastProductPrice();
            return Ok(value);
        }

        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            var value = _statisticsRepository.NewestBuildingYear();
            return Ok(value);
        }

        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            var value = _statisticsRepository.OldestBuildingYear();
            return Ok(value);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var value = _statisticsRepository.PassiveCategoryCount();
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _statisticsRepository.ProductCount();
            return Ok(value);
        }
    }
}
