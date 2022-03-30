using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LanguagesCourse.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try 
            {
                var response = await _registrationService.GetAllAsync();

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
        public async Task<IActionResult> CreateAsync([FromBody] RegistrationDTO model)
        {
            try 
            {
                var response = await _registrationService.CreateAsync(model);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try 
            {
                var response = await _registrationService.DeleteAsync(id);

                if (!response)
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