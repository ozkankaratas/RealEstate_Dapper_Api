using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactAsyn()
        {
            var values = await _contactRepository.GetAllContactAsyn();
            return Ok(values);
        }

        [HttpGet("GetLastFourContact")]
        public async Task<IActionResult> GetLastFourContact()
        {
            var values = await _contactRepository.GetLastFourContact();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _contactRepository.GetContact(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactRepository.CreateContact(createContactDto);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return Ok("Başarıyla Silindi");
        }
    }
}
