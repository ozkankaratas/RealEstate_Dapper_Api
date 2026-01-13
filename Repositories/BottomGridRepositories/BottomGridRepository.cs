using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "INSERT INTO BottomGrid (Icon, Title, Description) VALUES (@Icon, @Title, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", createBottomGridDto.Icon);
            parameters.Add("@Title", createBottomGridDto.Title);
            parameters.Add("@Description", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "DELETE FROM BottomGrid WHERE BottomGridID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsyn()
        {
            string query = "SELECT * FROM BottomGrid";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "SELECT * FROM BottomGrid WHERE BottomGridID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "UPDATE BottomGrid SET Icon = @Icon, Title = @Title, Description = @Description WHERE BottomGridID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", updateBottomGridDto.Icon);
            parameters.Add("@Title", updateBottomGridDto.Title);
            parameters.Add("@Description", updateBottomGridDto.Description);
            parameters.Add("@Id", updateBottomGridDto.BottomGridID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
