using Microsoft.AspNetCore.Mvc;
using MakFood.Customer.Application.Commands.ProfileThumbnail;
using MediatR;

namespace MakFood.Customer.Presentation.ApiControllers.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileThumbnailController : ControllerBase
{
    private readonly IMediator _mediator;


    public ProfileThumbnailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch("set-or-update")]
    public async Task<IActionResult> SetOrUpdate([FromBody] SetOrUpdateProfileThumbnailCommand command)
    {
        
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Remove(Guid userId)
    {
        var command = new RemoveProfileThumbnailCommand
        {
            UserId = userId,
            
        };

        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
