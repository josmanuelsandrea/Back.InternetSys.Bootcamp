using BackendBootcamp.Models;
using BackendBootcamp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendBootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequestModel model)
        {

            var response = await _authService.ReturnToken(model);

            if (response == null)
            {
                return Unauthorized();
            }

            if (response.Token == null)
            {
                return BadRequest(response.Msg);
            }

            return Ok(response);

        }

    }
}
