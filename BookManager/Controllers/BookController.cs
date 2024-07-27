using BookManager.Application.Commands.BooksCommands.CreateBook;
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
            var books = await _mediator.Send(query);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var book = await _mediator.Send(query);

            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
