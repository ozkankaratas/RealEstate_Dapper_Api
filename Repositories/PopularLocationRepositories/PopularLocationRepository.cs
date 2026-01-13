using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;
        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "INSERT INTO PopularLocation (CityName, ImageUrl) VALUES (@CityName, @ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@CityName", createPopularLocationDto.CityName);
            parameters.Add("@ImageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeletePopularLocation(int id)
        {
            string query = "DELETE FROM PopularLocation WHERE LocationID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsyn()
        {
            string query = "SELECT * FROM PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "SELECT * FROM PopularLocation WHERE LocationID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parameters);
                return value;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "UPDATE PopularLocation SET CityName = @CityName, ImageUrl = @ImageUrl WHERE LocationID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@CityName", updatePopularLocationDto.CityName);
            parameters.Add("@ImageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@Id", updatePopularLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
