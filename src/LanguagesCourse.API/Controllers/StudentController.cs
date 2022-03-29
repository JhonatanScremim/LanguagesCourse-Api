using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LanguagesCourse.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] StudentDTO model)
        {
            try
            {
                var response = await _studentService.CreateAsync(model);

                return Created("Created", response);
            }
            catch(BadRequestException e)
            {
                return BadRequest("Error: " + e);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error: " + e.Message);
            }
        }
    }
}