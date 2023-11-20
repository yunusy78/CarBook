using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers;


public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;
    
    public UpdatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
      var pricing = await _repository.GetByIdAsync(request.PricingId);
      pricing.Name = request.Name;
      await _repository.UpdateAsync(pricing);
      
    }
}
