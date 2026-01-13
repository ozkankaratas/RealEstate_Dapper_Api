using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;
        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = "INSERT INTO Services (ServiceName, ServiceStatus) VALUES (@ServiceName, @ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "DELETE FROM Services WHERE ServiceID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsyn()
        {
            string query = "SELECT * From Services";
            using(var connection = _context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "SELECT * FROM Services WHERE ServiceID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return value;
            }
        }

        public void UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = "UPDATE Services SET ServiceName = @ServiceName, ServiceStatus = @ServiceStatus WHERE ServiceID = @ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", updateServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@ServiceID", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
