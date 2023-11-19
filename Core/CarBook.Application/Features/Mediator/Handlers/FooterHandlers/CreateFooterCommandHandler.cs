using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;

public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
{
    private readonly IRepository<Footer> _featureRepository;
    
    public CreateFooterCommandHandler(IRepository<Footer> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
    {
        var footer = new Footer
        {
            Title = request.Title,
            Description = request.Description,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            
        };
        await _featureRepository.AddAsync(footer);
    }
}
