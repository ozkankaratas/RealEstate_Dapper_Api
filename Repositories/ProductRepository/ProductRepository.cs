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
            string query = "INSERT INTO Product (Title, Price, City, District, CoverImage, Semt, Latitude, Longitude, Neighborhood, Description, Type, DealOfTheDay, Date, Status, ProductCategory, AppUserId) " +
               "VALUES (@Title, @Price, @City, @District, @CoverImage, @Semt, @Latitude, @Longitude, @Neighborhood, @Description, @Type, @DealOfTheDay, @Date, @Status, @ProductCategory, @AppUserId)";

            var parameters = new DynamicParameters(createProductDto);

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
            string query = "UPDATE Product SET Title = @Title, Price = @Price, City = @City, District = @District, CoverImage = @CoverImage, Semt = @Semt, Neighborhood = @Neighborhood, Latitude = @Latitude, Longitude = @Longitude, Description = @Description, Type = @Type, DealOfTheDay = @DealOfTheDay,  Date = @Date, Status = @Status, ProductCategory = @ProductCategory WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters(updateProductDto);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task CreateProductDetail(CreateProductDetailDto createProductDetailDto, int id)
        {
            string query = "INSERT INTO ProductDetails (ProductSize, BedroomCount, BathroomCount, RoomCount, GarageSize, BuildYear, VideoUrl, ProductID) " +
                           "VALUES (@ProductSize, @BedroomCount, @BathroomCount, @RoomCount, @GarageSize, @BuildYear, @VideoUrl, @ProductID)";
            var parameters = new DynamicParameters(createProductDetailDto);
            parameters.Add("@ProductID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteProductDetail(int id)
        {
            string query = "DELETE FROM ProductDetails WHERE ProductDetailID = @ProductDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto, int id)
        {
            string query = "UPDATE ProductDetails SET ProductSize = @ProductSize, BedroomCount = @BedroomCount, BathroomCount = @BathroomCount, RoomCount = @RoomCount, GarageSize = @GarageSize, BuildYear = @BuildYear, VideoUrl = @VideoUrl, ProductID = @ProductID, WHERE ProductDetailID = @ProductDetailID";
            var parameters = new DynamicParameters(updateProductDetailDto);
            parameters.Add("@ProductID", id);
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
            string query = "SELECT p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName, p.CoverImage AS CoverImage, p.Type, p.DealOfTheDay, p.Status,  p.Date " +
                           "FROM Product p " +
                           "INNER JOIN Category c ON p.ProductCategory = c.CategoryId " +
                           "WHERE p.AppUserId = @appUserId AND p.Status = 1";
            var parameters = new DynamicParameters();
            parameters.Add("appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetPassiveProductAdvertListByEmployeeAsyn(int id)
        {
            string query = "SELECT p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName, p.CoverImage AS CoverImage, p.Type, p.DealOfTheDay, p.Status, p.Date " +
                           "FROM Product p " +
                           "INNER JOIN Category c ON p.ProductCategory = c.CategoryId " +
                           "WHERE p.AppUserId = @appUserId AND p.Status = 0";
            var parameters = new DynamicParameters();
            parameters.Add("appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsByIdWithCategoryAsync(int id)
        {
            string query = "SELECT TOP(5) p.*, c.CategoryName FROM Product p INNER JOIN Category c ON p.ProductCategory = c.CategoryId Where AppUserId=@appUserId ORDER BY p.ProductId DESC";
            var parameters = new DynamicParameters();
            parameters.Add("appUserId", id);
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

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchValue, int propertyCategoryId, string city)
        {
            string query = @"
                SELECT 
                    p.*, 
                    c.CategoryName, 
                    ct.CityName, 
                    d.DistrictName, 
                    n.NeighborhoodName, 
                    s.SemtName
                FROM Product p
                LEFT JOIN Category c ON p.ProductCategory = c.CategoryId
                LEFT JOIN Cities ct ON p.City = ct.CityID
                LEFT JOIN Districts d ON p.District = d.DistrictID
                LEFT JOIN Neighborhoods n ON p.Neighborhood = n.NeighborhoodID
                LEFT JOIN Semts s ON p.Semt = s.SemtID
                WHERE p.Status = 1";

            var parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(city) && city != "0")
            {
                query += " AND p.City = @City";
                parameters.Add("@City", city);
            }
            if (propertyCategoryId > 0)
            {
                query += " AND p.ProductCategory = @PropertyCategoryId";
                parameters.Add("@PropertyCategoryId", propertyCategoryId);
            }



            if (!string.IsNullOrEmpty(searchValue))
            {
                query += " AND (p.Title LIKE @SearchValue OR p.Description LIKE @SearchValue)";
                parameters.Add("@SearchValue", $"%{searchValue}%");
            }

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
