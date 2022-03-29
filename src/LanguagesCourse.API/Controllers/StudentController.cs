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
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _studentService.GetAllAsync();

                if (response == null)
                    return NoContent();
                
                return Ok(response);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error: " + e.Message);
            }
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] StudentUpdateDTO model, int id)
        {
            try
            {
                return Ok(await _studentService.UpdateAsync(model, id));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _studentService.DeleteAsync(id);

                if(response == false)
                    return BadRequest();

                return Ok("Success");
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