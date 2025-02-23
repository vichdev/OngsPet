using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngsPet.Communication.Requests;
using OngsPet.Communication.Responses;

namespace OngsPet.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserDTO), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserDTO request)
        {
            return Created();
        }
    }
}
