using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;

public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
{
    private readonly IRepository<Footer> _featureRepository;
    
    public GetFooterQueryHandler(IRepository<Footer> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
    {
        var footers = await _featureRepository.ListAllAsync();
        var result = footers.Select(x => new GetFooterQueryResult
        {
            FooterId = x.FooterId,
            Title = x.Title,
            Description = x.Description,
            Email = x.Email,
            Phone = x.Phone,
            Address = x.Address,
            
        }).ToList();
        return result;
    }
}