using BookManager.Application.Commands.LoansCommands.CreateLoan;
using BookManager.Application.Commands.LoansCommands.FinishLoan;
using BookManager.Application.Commands.LoansCommands.RenewLoan;
using BookManager.Application.Queries.LoansQueries.GetAllLoan;
using BookManager.Application.Queries.LoansQueries.GetLonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
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
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLoanByIdQuery(id);
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("finish/{id}")]
        public async Task<IActionResult> FinishLoan(int id)
        {
            var command = new FinishLoanCommand(id);
            
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result?.Message);

            return NoContent();
        }

        [HttpPut("renew/{id}")]
        public async Task<IActionResult> RenewLoan(int id)
        {
            var command = new RenewLoanCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result?.Message);

            return NoContent();
        }
    }
}
