using System.Linq.Expressions;
using BusinessLayer.Abstract;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace BusinessLayer.Concrete;

public class StatisticManager : IStatisticService
{
    private readonly IStatisticRepository _statisticRepository;
    
    public StatisticManager(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    

    public int GetCarCount()
    {
        var result = _statisticRepository.GetCarCount();
        return result;
    }

    public int GetBrandCount()
    {
        var result = _statisticRepository.GetBrandCount();
        return result;
    }

    public int GetBlogCount()
    {
        var result = _statisticRepository.GetBlogCount();
        return result;
    }

    public int GetAuthorCount()
    {
        var result = _statisticRepository.GetAuthorCount();
        return result;
    }

    public string GetHighestPriceCar()
    {
       var result = _statisticRepository.GetHighestPriceCar();
       return result;
    }

    public string GetLowestPriceCar()
    {
        var result = _statisticRepository.GetLowestPriceCar();
        return result;
    }

    public string GetMostRentedCarModel()
    {
        var result = _statisticRepository.GetMostRentedCarModel();
        return result;
    }

    public string GetMinRentedCarModel()
    {
        var result = _statisticRepository.GetMinRentedCarModel();
        return result;
    }
}