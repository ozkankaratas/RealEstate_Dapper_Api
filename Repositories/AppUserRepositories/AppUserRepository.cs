using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;
        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = @"
                SELECT 
                    u.UserId, 
                    u.Name, 
                    u.Email, 
                    u.Phone, 
                    u.UserImageUrl, 
                    p.AppUserId 
                FROM AppUser u
                INNER JOIN Product p ON u.UserId = p.AppUserId
                WHERE p.ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values ?? new GetAppUserByProductIdDto();
            }
        }
    }
}
