using RealEstate_Dapper_Api.Dtos.LocationDtos;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public interface ILocationRepository
    {
        Task<List<ResultCityDto>> GetAllCitiesAsync();
        Task<List<ResultDistrictDto>> GetAllDistrictsByCityIdAsync(int id);
        Task<List<ResultSemtDto>> GetAllSemtsByDistrictIdAsync(int id);
        Task<List<ResultNeighborhoodDto>> GetAllNeighborhoodsBySemtIdAsync(int id);
    }
}
