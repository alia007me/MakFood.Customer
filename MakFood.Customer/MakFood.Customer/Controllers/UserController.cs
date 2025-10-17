using MakFood.Customer.Application.Commands.AddUserAddress;
using MakFood.Customer.Application.Commands.RegisterUser;
using MakFood.Customer.Application.Commands.RemoveUserAddress;
using MakFood.Customer.Application.Commands.UpdateUser;
using MakFood.Customer.Application.Commands.UpdateUserAddress;
using MakFood.Customer.Application.Commands.UpdateUserInformation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Customer.Controllers
{
    [ApiController]
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

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }

        [HttpPost("{id}/Address")]
        public async Task<IActionResult> AddUserAddress([FromBody] AddUserAddressCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }

        [HttpPut("{id}/Address/{Addresid}")]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }

        [HttpDelete("{id}/Address/{Addresid}")]
        public async Task<IActionResult> RemoveUserAddress([FromBody] RemoveUserAddressCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIdentityInformation([FromBody] UpdateUserInformationCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest("empty or wrong input");

            var target = await _mediator.Send(command, ct);

            return Ok(target);
        }


    }
}
