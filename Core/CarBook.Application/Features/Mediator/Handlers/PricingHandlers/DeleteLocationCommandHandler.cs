using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers;

public class DeletePricingCommandHandler : IRequestHandler<DeletePricingCommand>
{
    private readonly IRepository<Pricing> _repository;
    
    public DeletePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeletePricingCommand request, CancellationToken cancellationToken)
    {
        var pricing = await _repository.GetByIdAsync(request.PricingId);
       await _repository.DeleteAsync(pricing);
    }
}