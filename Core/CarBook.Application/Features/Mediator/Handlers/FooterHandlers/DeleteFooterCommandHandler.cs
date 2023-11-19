using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;

public class DeleteFooterCommandHandler : IRequestHandler<DeleteFooterCommand>
{
    private readonly IRepository<Footer> _featureRepository;
    
    public DeleteFooterCommandHandler(IRepository<Footer> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(DeleteFooterCommand request, CancellationToken cancellationToken)
    {
        var footer = await _featureRepository.GetByIdAsync(request.FooterId);
       await _featureRepository.DeleteAsync(footer);
    }
}