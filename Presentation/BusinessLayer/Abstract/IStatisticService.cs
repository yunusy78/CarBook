using CarBook.Domain.Entities;

namespace BusinessLayer.Abstract;

public interface IStatisticService
{
    
    int GetCarCount();
    int GetBrandCount();
    int GetBlogCount();
    int GetAuthorCount();
    string GetHighestPriceCar();
    string GetLowestPriceCar();
    string GetMostRentedCarModel();
    string GetMinRentedCarModel();
    
    
    
    
    
    
    
}