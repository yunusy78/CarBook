using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;


public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
{
    private readonly IRepository<Footer> _featureRepository;
    
    public UpdateFooterCommandHandler(IRepository<Footer> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
    {
      var footer = await _featureRepository.GetByIdAsync(request.FooterId);
      footer.Title = request.Title;
      footer.Description = request.Description;
      footer.Email = request.Email;
      footer.Phone = request.Phone;
      footer.Address = request.Address;
      await _featureRepository.UpdateAsync(footer);
    }
}
