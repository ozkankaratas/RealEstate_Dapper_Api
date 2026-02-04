using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;
        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }            
        }

        public int ActiveEmployeeCount()
        {
            string query = "SELECT COUNT(*) FROM Employee WHERE Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ApartmentCount()
        {
            string query = "SELECT COUNT(*) FROM Product WHERE ProductCategory = 3";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int AvarageRoomCount()
        {
            string query = "SELECT AVG(RoomCount) FROM ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "SELECT AVG(Price) FROM Product WHERE Type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "SELECT AVG(Price) FROM Product WHERE Type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public int CategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string CategoryNameWithMaxProductCount()
        {
            string query = "SELECT TOP 1 CategoryName, COUNT(*) AS ProductCount FROM Category INNER JOIN Product ON Category.CategoryID = Product.ProductCategory GROUP BY Category.CategoryName ORDER BY ProductCount DESC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string CityNameWithMaxProductCount()
        {
            string query = "SELECT TOP 1 City, COUNT(*) AS ProductCount FROM Product GROUP BY City ORDER BY ProductCount DESC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int CityCount()
        {
            string query = "SELECT COUNT(DISTINCT City) FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string EmployeeNameWithMaxProductCount()
        {
            string query = "SELECT TOP 1 Name, COUNT(*) as ProductCount From Product INNER JOIN Employee ON Product.AppUserId = Employee.EmployeeID GROUP BY Name ORDER BY COUNT(*) DESC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
            throw new NotImplementedException();

        }

        public decimal LastProductPrice()
        {
            string query = "SELECT TOP 1 Price FROM Product ORDER BY ProductID DESC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "SELECT TOP 1 BuildYear FROM ProductDetails ORDER BY BuildYear DESC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "SELECT TOP 1 BuildYear FROM ProductDetails ORDER BY BuildYear ASC";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCount()
        {
            string query = "SELECT COUNT(*) FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
    }
}
