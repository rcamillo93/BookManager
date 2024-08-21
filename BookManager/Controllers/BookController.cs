using BookManager.Application.Commands.BooksCommands.CreateBook;
using BookManager.Application.Commands.BooksCommands.UpdateBook;
using BookManager.Application.Queries.BooksQueries.FindBookByTitle;
using BookManager.Application.Queries.BooksQueries.GetAllBooks;
using BookManager.Application.Queries.BooksQueries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();

            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);

            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("find")]
        public async Task<IActionResult> GetBookByName([FromQuery] string? title, [FromQuery] string? author)
        {
            var query = new FindBookQuery(title, author);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess) 
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetBookById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
