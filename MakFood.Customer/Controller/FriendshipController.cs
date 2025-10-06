using MakFood.Customer.Application.CommandHandler._ّFriendShipe;
using MakFood.Customer.Infrstructure.DataAccess.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Customer.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class FriendshipController : ControllerBase
    {

        private readonly ISender _sender;

        public FriendshipController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// ایجاد درخواست دوستی
        /// </summary>
        [HttpPost("add")]
        public async Task<IActionResult> AddFriend([FromBody] FriendshipCommand command)
        {
            command = command with { Action = "Add" };
            var result = await _sender.Send(command);
            if (result) return Ok("Friend request sent.");
            return BadRequest("Failed to send friend request.");
        }

        /// <summary>
        /// پذیرش درخواست دوستی
        /// </summary>
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriend([FromBody] FriendshipCommand command)
        {
            command = command with { Action = "Accept" };
            var result = await _sender.Send(command);
            if (result) return Ok("Friend request accepted.");
            return BadRequest("Failed to accept friend request.");
        }

        /// <summary>
        /// رد درخواست دوستی
        /// </summary>
        [HttpPost("reject")]
        public async Task<IActionResult> RejectFriend([FromBody] FriendshipCommand command)
        {
            command = command with { Action = "Reject" };
            var result = await _sender.Send(command);
            if (result) return Ok("Friend request rejected.");
            return BadRequest("Failed to reject friend request.");
        }

        /// <summary>
        /// لغو دوستی یا درخواست دوستی
        /// </summary>
        [HttpPost("cancel")]
        public async Task<IActionResult> CancelFriend([FromBody] FriendshipCommand command)
        {
            command = command with { Action = "Cancel" };
            var result = await _sender.Send(command);
            if (result) return Ok("Friendship canceled.");
            return BadRequest("Failed to cancel friendship.");
        }
    }
}
