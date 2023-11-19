using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands;

public class DeleteFeatureCommand : IRequest
{
    public DeleteFeatureCommand(int featureId)
    {
        FeatureId = featureId;
    }

    public int FeatureId { get; set; }
    
    
    
    
}