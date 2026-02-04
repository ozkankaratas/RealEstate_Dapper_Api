using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;
        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int ActiveProductCount(int id)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE AppUserId=@appUserId AND Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int PassiveProductCount(int id)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE AppUserId=@appUserId AND Status=0";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int AllProductCount()
        {
            string query = "SELECT COUNT(*) FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }       

        public int ProductCountByEmployeeId(int id)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE AppUserId=@appUserId";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id); 
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
