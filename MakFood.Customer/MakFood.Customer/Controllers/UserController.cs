using MakFood.Customer.Application.Commands.RegisterUser;
using MakFood.Customer.Application.Commands.UpdateUser;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Customer.Controllers
{
    [Controller]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command,ct);

            return Ok(target);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }

    }
}
