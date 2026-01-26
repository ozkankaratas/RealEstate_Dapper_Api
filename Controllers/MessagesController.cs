using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("ReceivedMessages")]
        public async Task<IActionResult> GetAllReceivedMessages(int id)
        {
            var result = await _messageRepository.GetAllReceivedMessages(id);
            return Ok(result);
        }

        [HttpGet("SendedMessages")]
        public async Task<IActionResult> GetAllSendedMessages(int id)
        {
            var result = await _messageRepository.GetAllSendedMessages(id);
            return Ok(result);
        }

        [HttpGet("LastThreeReceivedMessages")]
        public async Task<IActionResult> GetLastThreeMessagesListByReceiver(int id)
        {
            var result = await _messageRepository.GetLastThreeMessagesListByReceiver(id);
            return Ok(result);
        }
    }
}
