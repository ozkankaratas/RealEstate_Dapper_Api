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
            //string query = "INSERT INTO Services (ServiceName, ServiceStatus) VALUES (@serviceName, @serviceStatus)";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceName", createServiceDto.ServiceName);
            //parameters.Add("@serviceStatus", true);
            //using(var connection = _context.CreateConnection())
            //{
            //   connection.ExecuteAsync(query, parameters);
            //}
        }

        public async void DeleteService(int id)
        {
            //string query = "DELETE FROM Services WHERE ServiceId = @serviceId";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", id);
            //using (var connection = _context.CreateConnection())
            //{
            //    connection.ExecuteAsync(query, parameters);
            //}
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
            //string query = "SELECT * FROM Services WHERE ServiceID = @serviceID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", id);
            //using (var connection = _context.CreateConnection())
            //{
            //    var values = connection.QueryFirstOrDefault<GetByIDServiceDto>(query, parameters);
            //    return values;
            //}
            return null;
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            //string query = "UPDATE Services SET ServiceName = @serviceName, ServiceStatus = @serviceStatus WHERE ServiceID = @serviceID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", updateServiceDto.ServiceID);
            //parameters.Add("@serviceName", updateServiceDto.ServiceName);
            //parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            //using (var connection = _context.CreateConnection())
            //{
            //    connection.ExecuteAsync(query, parameters);
            //}
        }
    }
}
