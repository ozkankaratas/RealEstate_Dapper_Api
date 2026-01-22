using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "SELECT * FROM AppUser U INNER JOIN AppRole R ON U.UserRole = R.RoleId WHERE U.Username = @Username AND U.Password = @Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Username", loginDto.Username);
            parameters.Add("@Password", loginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserInfoDto>(query, parameters);

                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.UserName = values.Username;
                    model.Id = values2.UserId;
                    model.RoleName = values2.RoleName;
                    
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Geçersiz Kullanıcı Adı Veya Şifre");
                }
            }

        }
    }
}
