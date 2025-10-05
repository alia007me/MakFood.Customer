using MakFood.Customer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Application.CommandHandler.CreateUser;
using System.Threading.Tasks;
using MediatR;
using MakFood.Customer.Application.CommandHandler.AddAddres;

namespace MakFood.Customer.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISender _sender;
        public UserController(IUserRepository userRepository, ISender sender)
        {
            _userRepository = userRepository;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var userid = await _sender.Send(command);
            return Ok(userid);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> AddAddress(AddAddresCommand command)
        {
            var addresId = await _sender.Send(command);
            return Ok(addresId);
        }


    }
}
