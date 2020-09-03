using System.Threading.Tasks;
using JansenVerhuurAPI.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace JansenVerhuurAPI.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var authResponse = await _mediator.Send(request);

           if (!authResponse.Success)
           {
               return BadRequest(authResponse.Errors);
           }

           return Ok(authResponse.Token);
        }
        
    }
}