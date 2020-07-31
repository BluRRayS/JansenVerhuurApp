using System.Threading.Tasks;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Exceptions;

namespace JansenVerhuurAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.User.GetAll)]
        public async Task<IActionResult> Users()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.Get)]
        public async Task<IActionResult> UserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.User.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(UserById), new {id = result.Id}, result);
        }

        [HttpDelete(ApiRoutes.User.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand {Id = id});
            if (!result) return NotFound();
            return Ok();
        }

        [HttpPut(ApiRoutes.User.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(UserById), new {id = result.Id}, result);
            }
            catch (NotFoundException)
            {
                _logger.LogWarning("Could not find user with Id: " + command.Id + " when updating");
                return NotFound();
            }
        }
    }
}