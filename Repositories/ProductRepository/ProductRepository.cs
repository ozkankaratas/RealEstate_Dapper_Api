using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "INSERT INTO Product (Title, Price, City, District, CoverImage, Address, Description, Type, DealOfTheDay, Date, Status, ProductCategory, EmployeeId) " +
                           "VALUES (@Title, @Price, @City, @District, @CoverImage, @Address, @Description, @Type, @DealOfTheDay, @Date, @Status, @ProductCategory, @EmployeeId)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", createProductDto.Title);
            parameters.Add("Price", createProductDto.Price);
            parameters.Add("City", createProductDto.City);
            parameters.Add("District", createProductDto.District);
            parameters.Add("CoverImage", createProductDto.CoverImage);
            parameters.Add("Address", createProductDto.Address);
            parameters.Add("Description", createProductDto.Description);
            parameters.Add("Type", createProductDto.Type);
            parameters.Add("DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("Date", createProductDto.Date);
            parameters.Add("Status", createProductDto.Status);
            parameters.Add("ProductCategory", createProductDto.ProductCategory);
            parameters.Add("EmployeeId", createProductDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteProduct(int id)
        {
            string query = "DELETE FROM Product WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            string query = "UPDATE Product SET Title = @Title, Price = @Price, City = @City, District = @District, CoverImage = @CoverImage, Address = @Address, Description = @Description, Type = @Type, DealOfTheDay = @DealOfTheDay,  Date = @Date, Status = @Status, ProductCategory = @ProductCategory WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("ProductID", updateProductDto.ProductID);
            parameters.Add("Title", updateProductDto.Title);
            parameters.Add("Price", updateProductDto.Price);
            parameters.Add("City", updateProductDto.City);
            parameters.Add("District", updateProductDto.District);
            parameters.Add("CoverImage", updateProductDto.CoverImage);
            parameters.Add("Address", updateProductDto.Address);
            parameters.Add("Description", updateProductDto.Description);
            parameters.Add("Type", updateProductDto.Type);
            parameters.Add("DealOfTheDay", updateProductDto.DealOfTheDay);
            parameters.Add("Date", updateProductDto.Date);
            parameters.Add("Status", updateProductDto.Status);
            parameters.Add("ProductCategory", updateProductDto.ProductCategory);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDProductDto> GetProductById(int id)
        {
            string query = "SELECT p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId where ProductId = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<GetByIDProductDto>(query, parameters);
                return value.FirstOrDefault();
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsyn()
        {
            string query = "SELECT * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "SELECT p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsWithCategoryAsync()
        {
            string query = "SELECT TOP(5) p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId WHERE p.Status= 1 ORDER BY p.ProductId DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "UPDATE Product SET DealOfTheDay = 0 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "UPDATE Product SET DealOfTheDay = 1 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task ProductStatusChangeToFalse(int id)
        {
            string query = "UPDATE Product SET Status = 0 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task ProductStatusChangeToTrue(int id)
        {
            string query = "UPDATE Product SET Status = 1 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetActiveProductAdvertListByEmployeeAsyn(int id)
        {
            string query = "SELECT p.ProductID, p.Title, p.Price, p.City, p.District, p.Address, c.CategoryName, p.CoverImage AS CoverImage, p.Type, p.DealOfTheDay, p.Status,  p.Date " +
                           "FROM Product p " +
                           "INNER JOIN Category c ON p.ProductCategory = c.CategoryId " +
                           "WHERE p.EmployeeID = @employeeID AND p.Status = 1";
            var parameters = new DynamicParameters();
            parameters.Add("employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetPassiveProductAdvertListByEmployeeAsyn(int id)
        {
            string query = "SELECT p.ProductID, p.Title, p.Price, p.City, p.District, p.Address, c.CategoryName, p.CoverImage AS CoverImage, p.Type, p.DealOfTheDay, p.Status, p.Date " +
                           "FROM Product p " +
                           "INNER JOIN Category c ON p.ProductCategory = c.CategoryId " +
                           "WHERE p.EmployeeID = @employeeID AND p.Status = 0";
            var parameters = new DynamicParameters();
            parameters.Add("employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsByIdWithCategoryAsync(int id)
        {
            string query = "SELECT TOP(5) p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId Where EmployeeID=@employeeId ORDER BY p.ProductId DESC";
            var parameters = new DynamicParameters();
            parameters.Add("employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailById(int id)
        {
            string query = "SELECT * FROM ProductDetails WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }
    }
}
