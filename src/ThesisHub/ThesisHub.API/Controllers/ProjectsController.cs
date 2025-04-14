using System.ComponentModel.Design.Serialization;
using Microsoft.AspNetCore.Mvc;
using ThesisHub.Application.Services;
using ThesisHub.Common.Dtos;

namespace ThesisHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet("Get/{id}")]
        public async Task<ProjectDto> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<List<ProjectDto>> GetAll(string filter = "")
        {
            return await _service.GetAll(filter);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] ProjectDto dto)
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
        public async Task<IActionResult> Update([FromBody] ProjectDto dto)
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
