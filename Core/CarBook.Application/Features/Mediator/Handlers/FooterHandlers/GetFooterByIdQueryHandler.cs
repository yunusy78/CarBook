using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;

public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
{
    private readonly IRepository<Footer> _featureRepository;
    
    public GetFooterByIdQueryHandler(IRepository<Footer> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
    {
        var footer = await _featureRepository.GetByIdAsync(request.FooterId);
        var result = new GetFooterByIdQueryResult
        {
            FooterId = footer.FooterId,
            Title = footer.Title,
            Description = footer.Description,
            Email = footer.Email,
            Phone = footer.Phone,
            Address = footer.Address,
            
        };
        return result;
    }
}
