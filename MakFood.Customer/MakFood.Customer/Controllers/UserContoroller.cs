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

    [HttpPatch("{userId}/Profile/Thumbnail")]
    public async Task<IActionResult> SetOrUpdate([FromBody] SetOrUpdateProfileThumbnailCommand command)
    {
        
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // Users/4/Prrofile/Thumbnail

    [HttpDelete("{userId}/Profile/Thumbnail")]
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
