using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO Category (CategoryName, CategoryStatus) VALUES (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using(var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsyn()
        {
            string query = "SELECT * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "SELECT * FROM Category WHERE CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto CategoryDto)
        {
            string query = "UPDATE Category SET CategoryName = @categoryName, CategoryStatus = @categoryStatus WHERE CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", CategoryDto.CategoryName);
            parameters.Add("@categoryStatus", CategoryDto.CategoryStatus);
            parameters.Add("@categoryID", CategoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
