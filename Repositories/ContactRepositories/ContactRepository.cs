using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;
        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContact(CreateContactDto createContactDto)
        {
            string query = "INSERT INTO Contact (Name, Email, Subject, Message, SendDate) VALUES (@name, @email, @subject, @message, @sendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createContactDto.Name);
            parameters.Add("@email", createContactDto.Email);
            parameters.Add("@subject", createContactDto.Subject);
            parameters.Add("@message", createContactDto.Message);
            parameters.Add("@sendDate", createContactDto.SendDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "DELETE FROM Contact WHERE ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsyn()
        {
            string query = "SELECT * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContact(int id)
        {
            string query = "SELECT * FROM Contact WHERE ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<LastFourContactResultDto>> GetLastFourContact()
        {
            string query = "SELECT TOP 4 * From Contact ORDER BY SendDate DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<LastFourContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}
