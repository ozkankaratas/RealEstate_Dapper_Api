using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInboxMessageDto>> GetLastThreeMessagesListByReceiver(int id);
        Task<List<ResultInboxMessageDto>> GetAllReceivedMessages(int id);
        Task<List<ResultOutboxMessageDto>> GetAllSendedMessages(int id);

    }
}
