using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface IStatisticRepository
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