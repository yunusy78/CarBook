using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    
    private readonly IStatisticService _statisticService;
    
    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    
    [HttpGet("GetCarCount")]
    
    public IActionResult GetCarCount()
    {
        var result = _statisticService.GetCarCount();
        return Ok(result);
    }
    
    [HttpGet("GetBrandCount")]
    
    public IActionResult GetBrandCount()
    {
        var result = _statisticService.GetBrandCount();
        return Ok(result);
    }
    
    
    [HttpGet("GetBlogCount")]
    
    public IActionResult GetBlogCount()
    {
        var result = _statisticService.GetBlogCount();
        return Ok(result);
    }
    
    
    [HttpGet("GetAuthorCount")]
    
    
    public IActionResult GetAuthorCount()
    {
        var result = _statisticService.GetAuthorCount();
        return Ok(result);
    }
    
    
    [HttpGet("GetHighestPriceCar")]
    
    public IActionResult GetHighestPriceCar()
    {
        var result = _statisticService.GetHighestPriceCar();
        return Ok(result);
    }
    
    
    [HttpGet("GetLowestPriceCar")]
    
    
    public IActionResult GetLowestPriceCar()
    {
        var result = _statisticService.GetLowestPriceCar();
        return Ok(result);
    }
    
    
    [HttpGet("GetMostRentedCarModel")]
    
    
    public IActionResult GetMostRentedCarModel()
    {
        var result = _statisticService.GetMostRentedCarModel();
        return Ok(result);
    }
    
    
    [HttpGet("GetMinRentedCarModel")]
    
    
    public IActionResult GetMinRentedCarModel()
    {
        var result = _statisticService.GetMinRentedCarModel();
        return Ok(result);
    }
    
    
    
    
}