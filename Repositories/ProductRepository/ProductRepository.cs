using Dapper;
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

        public async void CreateProduct(CreateProductDto createProductDto)
        {
            string query = "INSERT INTO Product (Title, Price, City, District, Address, ProductCategory, CoverImage, Type, DealOfTheDay, Date) " +
                           "VALUES (@title, @price, @city, @district, @address, @productCategory, @coverImage, @type, @dealOfTheDay, @date)";
            var parameters = new DynamicParameters();
            parameters.Add("title", createProductDto.title);
            parameters.Add("price", createProductDto.price);
            parameters.Add("city", createProductDto.city);
            parameters.Add("district", createProductDto.district);
            parameters.Add("address", createProductDto.address);
            parameters.Add("productCategory", createProductDto.productCategory);
            parameters.Add("coverImage", createProductDto.coverimage);
            parameters.Add("type", createProductDto.type);
            parameters.Add("dealOfTheDay", false);
            parameters.Add("date", createProductDto.date);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteProduct(int id)
        {
            string query = "DELETE FROM Product WHERE ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateProduct(UpdateProductDto updateProductDto)
        {
            string query = "UPDATE Product SET Title = @title, Price = @price, City = @city, District = @district, " +
                           "Address = @address, ProductCategory = @productCategory, CoverImage = @coverImage, " +
                           "Type = @type, DealOfTheDay = @dealOfTheDay, Date = @date WHERE ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("productID", updateProductDto.productID);
            parameters.Add("title", updateProductDto.title);
            parameters.Add("price", updateProductDto.price);
            parameters.Add("city", updateProductDto.city);
            parameters.Add("district", updateProductDto.district);
            parameters.Add("address", updateProductDto.address);
            parameters.Add("productCategory", updateProductDto.productCategory);
            parameters.Add("coverImage", updateProductDto.coverimage);
            parameters.Add("type", updateProductDto.type);
            parameters.Add("dealOfTheDay", updateProductDto.dealOfTheDay);
            parameters.Add("date", updateProductDto.date);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<GetByIDProductDto> GetProduct(int id)
        {
            string query = "SELECT * FROM Product WHERE ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("productID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QuerySingleOrDefaultAsync<GetByIDProductDto>(query, parameters);
                return value;
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
            string query = "SELECT TOP(5) p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId ORDER BY p.ProductId DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }



        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "UPDATE Product SET DealOfTheDay = 0 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "UPDATE Product SET DealOfTheDay = 1 WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyn(int id)
        {
            string query = "SELECT p.ProductID, p.Title, p.Price, p.City, p.District, p.Address, c.CategoryName, p.CoverImage AS CoverImage, p.Type, p.DealOfTheDay, p.Date " +
                           "FROM Product p " +
                           "INNER JOIN Category c ON p.ProductCategory = c.CategoryId " +
                           "WHERE p.EmployeeID = @employeeID";
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
    }
}
