using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler
{
    private readonly IRepository<Brand> _repository;
    
    public GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request)
    {
      var brand=  await _repository.GetByIdAsync(request.BrandId);
        
        var brandDto = new GetBrandByIdQueryResult()
        {
            BrandId = brand.BrandId,
            BrandName = brand.BrandName
        };
        
        return brandDto;
    }
}