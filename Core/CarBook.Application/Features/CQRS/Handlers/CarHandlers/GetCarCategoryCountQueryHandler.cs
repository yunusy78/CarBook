using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarCategoryCountQueryHandler
{
    
    private readonly ICarRepository _repository;
    
    public GetCarCategoryCountQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }
    
    public Task<List<GetCarCategoryCountQueryResult>> Handle()
    {
        var cars = _repository.GetCarCountByCategory();
        
      var carsResults = cars.Select(car => new GetCarCategoryCountQueryResult()
        {
            CategoryName = car.Key,
            Count = car.Value
            
        }).ToList();
      
      return Task.FromResult(carsResults);
    }
    
    
    
    
    
    
    
}