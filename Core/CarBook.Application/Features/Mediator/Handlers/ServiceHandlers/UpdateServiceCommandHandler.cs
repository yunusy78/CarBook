using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers;


public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;
    
    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
      var service = await _repository.GetByIdAsync(request.ServiceId);
      service.Title = request.Title;
      service.Description = request.Description;
        service.ImageUrl = request.ImageUrl;
      await _repository.UpdateAsync(service);
    }
}
