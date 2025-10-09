using MakFood.Customer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Application.CommandHandler.CreateUser;
using System.Threading.Tasks;
using MediatR;
using MakFood.Customer.Application.CommandHandler.UpdateUser;

namespace MakFood.Customer.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _sender;
        public UserController(IUserRepository userRepository, IMediator sender)
        {
            _userRepository = userRepository;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken ct)
        {
            var userid = await _sender.Send(command, ct);
            return Ok(userid);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command, CancellationToken ct)
        {
            return Ok(await _sender.Send(command, ct));
        }

    }
}
