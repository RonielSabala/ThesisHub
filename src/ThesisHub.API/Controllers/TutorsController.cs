using Microsoft.AspNetCore.Mvc;
using ThesisHub.Application.Services;
using ThesisHub.Common.Dtos;

namespace ThesisHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorsController : ControllerBase
    {
        private readonly TutorService _service;

        public TutorsController(TutorService service)
        {
            _service = service;
        }

        [HttpGet("Get/{id}")]
        public async Task<TutorDto> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<List<TutorDto>> GetAll(string filter = "")
        {
            return await _service.GetAll(filter);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] TutorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model is Invalid");
            }

            var response = await _service.Add(dto);
            if (!response)
            {
                return StatusCode(500, new { success = false });
            }

            return Ok(new { success = true, message = "Created successfully!" });
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] TutorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model is Invalid");
            }

            var response = await _service.Update(dto);
            if (!response)
            {
                return StatusCode(500, new { success = false });
            }

            return Ok(new { success = true, message = "Updated successfully!" });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            if (!response)
            {
                return StatusCode(500, new { success = false });
            }

            return Ok(new { success = true, message = "Deleted successfully!" });
        }
    }
}
