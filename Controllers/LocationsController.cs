using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.LocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _locationRepository.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("GetDistricts/{cityId}")]
        public async Task<IActionResult> GetDistrictsByCityId(int cityId)
        {
            var districts = await _locationRepository.GetAllDistrictsByCityIdAsync(cityId);
            return Ok(districts);
        }

        [HttpGet("GetSemts/{districtId}")]
        public async Task<IActionResult> GetSemtsByDistrictId(int districtId)
        {
            var semts = await _locationRepository.GetAllSemtsByDistrictIdAsync(districtId);
            return Ok(semts);
        }

        [HttpGet("GetNeighborhoods/{semtId}")]
        public async Task<IActionResult> GetNeighborhoodsBySemtId(int semtId)
        {
            var neighborhoods = await _locationRepository.GetAllNeighborhoodsBySemtIdAsync(semtId);
            return Ok(neighborhoods);
        }
    }
}
