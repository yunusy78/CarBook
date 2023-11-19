using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandQueryHandler
{
    private readonly IRepository<Brand> _repository;
    
    public GetBrandQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var brands = await _repository.ListAllAsync();
        
        var brandsResults = brands.Select(banner => new GetBrandQueryResult()
        {
            BrandId = banner.BrandId,
            BrandName = banner.BrandName
        }).ToList();
        
        return brandsResults;
    }
    
}