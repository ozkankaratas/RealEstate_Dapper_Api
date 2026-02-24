using RealEstate_Dapper_Api.Dtos.LocationDtos;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public interface ILocationRepository
    {
        Task<List<ResultCityDto>> GetAllCities();
        Task<List<ResultDistrictDto>> GetAllDistrictsByCityId(int id);
        Task<List<ResultSemtDto>> GetAllSemtsByDistrictId(int id);
        Task<List<ResultNeighborhoodDto>> GetAllNeighborhoodsBySemtId(int id);
    }
}
