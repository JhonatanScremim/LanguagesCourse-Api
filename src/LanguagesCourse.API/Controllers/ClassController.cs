using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LanguagesCourse.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _classService.GetAllAsync();

                if (response == null || !response.Any())
                    return NoContent();

                return Ok(response);
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ClassDTO model)
        {
            try
            {
                var response = await _classService.CreateAsync(model);

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
        public async Task<IActionResult> UpdateAsync([FromBody] ClassDTO model, int id)
        {
            try
            {
                return Ok(await _classService.UpdateAsync(model, id));
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
                var response = await _classService.DeleteAsync(id);

                if(!response)
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