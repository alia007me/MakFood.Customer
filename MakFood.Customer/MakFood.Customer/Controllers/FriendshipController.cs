using MakFood.Customer.Application.Commands.Friendship.AcceptFriendship;
using MakFood.Customer.Application.Commands.Friendship.CreateFriendship;
using MakFood.Customer.Application.Commands.Friendship.RejectFriendship;
using MakFood.Customer.Application.Commands.Friendship.RevokeFriendship;
using MakFood.Customer.Application.Queries.GetActiveFriendships;
using MakFood.Customer.Application.Queries.GetRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendshipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFriendship([FromBody] CreateFriendshipCommand command, CancellationToken ct)
        {
            if (command == null)
            {
                return BadRequest("Input cannot be null or empty.");
            }

            await _mediator.Send(command, ct);

            return Ok();
        }

        [HttpPatch("{id}/accept")]
        public async Task<IActionResult> AcceptFriendship([FromBody] AcceptFriendshipCommand command, CancellationToken ct)
        {
            if (command == null)
            {
                return BadRequest("Input cannot be null or empty.");
            }

            await _mediator.Send(command, ct);

            return Ok();
        }

        [HttpPatch("{id}/reject")]
        public async Task<IActionResult> RejectFriendship([FromBody] RejectFriendshipCommand command, CancellationToken ct)
        {
            if (command == null)
            {
                return BadRequest("Input cannot be null or empty.");
            }

            await _mediator.Send(command, ct);

            return Ok();
        }

        [HttpPatch("{id}/Revoke")]
        public async Task<IActionResult> RevokeFriendship([FromBody] RevokeFriendshipCommand command, CancellationToken ct)
        {
            if (command == null)
            {
                return BadRequest("Input cannot be null or empty.");
            }

            await _mediator.Send(command, ct);

            return Ok();
        }

        [HttpGet("{userId}/Friendships/requests")]
        public async Task<ActionResult<List<GetRequestDto>>> GetUserFriendshipRequests(Guid userId)
        {
            
            var query = new GetRequestQuery { UserId = userId };

            var results = await _mediator.Send(query);
            return Ok(results);
        }

        [HttpGet("{userId}/Friendships/Accepteds")]
        public async Task<ActionResult<List<GetActiveFriendshipsDto>>> GetUserActiveFriendships(Guid userId)
        {

            var query = new GetActiveFriendshipsQuery { UserId = userId };

            var results = await _mediator.Send(query);
            return Ok(results);
        }



    }
}