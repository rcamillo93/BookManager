using BookManager.Application.Commands.LoansCommands.CreateLoan;
using BookManager.Application.Commands.LoansCommands.FinishLoan;
using BookManager.Application.Queries.LoansQueries.GetAllLoan;
using BookManager.Application.Queries.LoansQueries.GetLonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }    
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllLoansQuery();
            var loan = await _mediator.Send(query);

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetLoanByIdQuery(id);
            var loan = await _mediator.Send(query);

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            var command = new FinishLoanCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
