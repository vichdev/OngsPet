using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngsPet.Application.UseCases.User.Register;
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
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
