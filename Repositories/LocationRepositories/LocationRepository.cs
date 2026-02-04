using Dapper;
using RealEstate_Dapper_Api.Dtos.LocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Context _context;

        public LocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCityDto>> GetAllCitiesAsync()
        {
            string query = "SELECT CityID, CityName FROM Cities";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCityDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultDistrictDto>> GetAllDistrictsByCityIdAsync(int id)
        {
            string query = "SELECT DistrictID, DistrictName, CityID FROM Districts WHERE CityID = @CityID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDistrictDto>(query, new { CityID = id });
                return values.ToList();
            }
        }

        public async Task<List<ResultNeighborhoodDto>> GetAllNeighborhoodsBySemtIdAsync(int id)
        {
            string query = "SELECT NeighborhoodID, NeighborhoodName, SemtID FROM Neighborhoods WHERE SemtID = @SemtID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultNeighborhoodDto>(query, new { SemtID = id });
                return values.ToList();
            }
        }

        public async Task<List<ResultSemtDto>> GetAllSemtsByDistrictIdAsync(int id)
        {
            string query = "SELECT SemtID, SemtName, DistrictID FROM Semts WHERE DistrictID = @DistrictID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSemtDto>(query, new { DistrictID = id });
                return values.ToList();
            }
        }
    }
}
