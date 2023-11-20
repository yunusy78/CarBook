using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IRepository<Service> _repository;
    
    public DeleteServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var Service = await _repository.GetByIdAsync(request.ServiceId);
       await _repository.DeleteAsync(Service);
    }
}