using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDoListAsyn()
        {
            var values = await _toDoListRepository.GetAllToDoListAsyn();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id)
        {
            var value = await _toDoListRepository.GetToDoList(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            _toDoListRepository.CreateToDoList(createToDoListDto);
            return Ok("Listeye Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("İçerik Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("Başarıyla Silindi");
        }
    }
}
