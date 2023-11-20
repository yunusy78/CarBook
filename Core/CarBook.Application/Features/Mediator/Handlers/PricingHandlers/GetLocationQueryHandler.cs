using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers;

public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    private readonly IRepository<Pricing> _repository;
    
    public GetPricingQueryHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var pricings = await _repository.ListAllAsync();
        var result = pricings.Select(x => new GetPricingQueryResult
        {
            PricingId = x.PricingId,
            Name = x.Name
        }).ToList();
        return result;
    }
}