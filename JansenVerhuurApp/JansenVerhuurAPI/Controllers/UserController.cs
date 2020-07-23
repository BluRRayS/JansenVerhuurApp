using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JansenVerhuurAPI.Exceptions;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(template: "")]
        public async Task<IActionResult> Users()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> User(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost(template: "/Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(User), new { id = result.Id }, result);
        }

        [HttpDelete(template: "/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand() { Id = id });
            if (!result) return NotFound();
            return Ok();
        }

        [HttpPut(template: "/Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(User), new { id = result.Id }, result);
            }
            catch (NotFoundException)
            {
                _logger.LogWarning("Could not find user with Id: " + command.Id + " when updating");
                return NotFound();
            }
        }

    }
}
