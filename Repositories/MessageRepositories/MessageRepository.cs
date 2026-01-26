using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;
        public MessageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultInboxMessageDto>> GetLastThreeMessagesListByReceiver(int id)
        {
            string query = @"SELECT TOP(3) m.MessageId, u.Name AS 'SenderName', m.Subject, m.Detail, m.SendDate, m.IsRead, u.UserImageUrl
                    FROM Message m
                    INNER JOIN AppUser u ON m.Sender = u.UserId
                    WHERE m.Receiver = @receiverId 
                    ORDER BY m.MessageId DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<List<ResultInboxMessageDto>> GetAllReceivedMessages(int id)
        {
            string query = @"SELECT m.MessageId, u.Name AS 'SenderName', m.Subject, m.Detail, m.SendDate, m.IsRead, u.UserImageUrl 
                    FROM Message m
                    INNER JOIN AppUser u ON m.Sender = u.UserId
                    WHERE m.Receiver = @receiverId 
                    ORDER BY m.MessageId DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<List<ResultOutboxMessageDto>> GetAllSendedMessages(int id)
        {
            string query = @"SELECT m.MessageId, u.Name AS 'ReceiverName', m.Subject, m.Detail, m.SendDate, m.IsRead, u.UserImageUrl 
                    FROM Message m
                    INNER JOIN AppUser u ON m.Receiver = u.UserId
                    WHERE m.Sender = @senderId 
                    ORDER BY m.MessageId DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@senderId", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultOutboxMessageDto>(query, parameters);
                return result.ToList();
            }
        }
    }
}
