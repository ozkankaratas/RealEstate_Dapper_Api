using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductChartDto>> GetEmployeeProductCountByYearChart(int id)
        {
            string query = @"SELECT YEAR(Date) AS [Year], COUNT(*) AS ProductCount FROM Product WHERE EmployeeID = @employeeId GROUP BY YEAR(Date) ORDER BY [Year] DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductChartDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultChartDto>> GetTopCitiesByProductChart()
        {
            string query = @"SELECT TOP 7 City, COUNT(City) AS ProductCount
                             FROM Product
                             GROUP BY City
                             ORDER BY ProductCount DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}
