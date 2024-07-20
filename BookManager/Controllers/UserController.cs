using BookManager.Application.Commands.CreateUser;
using BookManager.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
