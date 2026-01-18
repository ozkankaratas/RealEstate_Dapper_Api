using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;
        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public async void CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            string query = "INSERT INTO ToDoList (Description, Status) VALUES (@Description, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", createToDoListDto.Description);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteToDoList(int id)
        {
            string query = "DELETE FROM ToDoList WHERE ToDoListID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsyn()
        {
            string query = "SELECT * FROM ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            string query = "SELECT * FROM ToDoList WHERE ToDoListID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            string query = "UPDATE ToDoList SET Description = @Description, Status = @Status WHERE ToDoListID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", updateToDoListDto.ToDoListID);
            parameters.Add("@Description", updateToDoListDto.Description);
            parameters.Add("@Status", updateToDoListDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
