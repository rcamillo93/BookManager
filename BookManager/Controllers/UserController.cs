using BookManager.Application.Commands.UsersCommands.CreateUser;
using BookManager.Application.Commands.UsersCommands.UpdateUser;
using BookManager.Application.Queries.UsersQueries.GetAllUsers;
using BookManager.Application.Queries.UsersQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, command);
        }

        [HttpPut("removerestriction/{id}")]
        public async Task<IActionResult> RemoveRestriction(int id)
        {
            var command = new RemoveRestrictionUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
