using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands;

public class DeletePricingCommand : IRequest
{
    public DeletePricingCommand(int id)
    {
        PricingId = id;
    }

    public int PricingId { get; set; }
    
    
    
    
}