using CarBook.Domain.Entities;

namespace Business.Abstract;

public interface IStatisticService
{
    
    Task<int> GetCarCount();
    Task<int> GetBrandCount();
    Task<int> GetBlogCount();
    Task<int> GetAuthorCount();
    Task<string> GetHighestPriceCar();
    Task<string>  GetLowestPriceCar();
    Task<string>  GetMostRentedCarModel();
    Task<string>  GetMinRentedCarModel();
    
    
    
    
    
    
    
}