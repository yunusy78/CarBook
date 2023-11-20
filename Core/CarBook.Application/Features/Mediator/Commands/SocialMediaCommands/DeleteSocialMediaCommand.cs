using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;

public class DeleteSocialMediaCommand : IRequest
{
    public DeleteSocialMediaCommand(int id)
    {
        SocialMediaId = id;
    }

    public int SocialMediaId { get; set; }
    
    
    
    
}