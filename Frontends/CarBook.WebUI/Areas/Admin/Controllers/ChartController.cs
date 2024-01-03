using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;
[Authorize]
[Area("Admin")]
public class ChartController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly ICarService _carService;
    private readonly ICarFeatureService _carFeatureService;
    private readonly IBlogService _blogService;
    private readonly IBlogCategoryService _blogCategoryService;
    
    public ChartController(IReservationService reservationService, ICarService carService, ICarFeatureService carFeatureService, IBlogService blogService, IBlogCategoryService blogCategoryService)
    {
        _reservationService = reservationService;
        _carService = carService;
        _carFeatureService = carFeatureService;
        _blogService = blogService;
        _blogCategoryService = blogCategoryService;
    }
    
    
    // GET
    public async Task<IActionResult> Index()
    {
        try
        {
            var reservationsWithCar = await _reservationService.GetAllAsync();
            
            var carCounts = reservationsWithCar
                .GroupBy(r => r.CarId)
                .Select(group => new
                {
                    Name = group.First().Car.Model,
                    Count = group.Count()
                })
                .ToList();

            return View(carCounts);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            return View(new List<object>()); // or an empty model depending on your View
        }
    }


    public IActionResult Index2()
    {
        return View();
    }
    
    
    public async Task<IActionResult> OrderChart()
    {

        var carList = await _carService.GetAllAsync();
        var jsonCar = new List<object>();

        foreach (var car in carList)
        {
            var orderCount =  _reservationService.GetAllAsync().Result.Count(x => x.CarId == car.CarId);
            var jsonOrderCount = new
            {
                Name = car.Model,
                Count = orderCount
            };
            jsonCar.Add(jsonOrderCount);
        }
        return Json(new { jsonlist = jsonCar });
    }
    
    public async Task<IActionResult> DailyChart()
    {
        try
        {
            var carList = await _carService.GetAllAsync();
            var jsonCar = new List<object>();

            foreach (var car in carList)
            {
                var orderCount = (await _reservationService.GetAllAsync())
                    .Count(x => x.PickUpDate.Day == DateTime.Today.Day && x.CarId == car.CarId);

                var jsonOrderCount = new
                {
                    Name = car.Model,
                    Count = orderCount
                };

                jsonCar.Add(jsonOrderCount);
            }


            return Json(new { jsonlist = jsonCar });
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately, log, and return an error response if needed.
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    
    public IActionResult RevenueChart()
    {
        var revenueByMonth =  _reservationService.GetAllAsync().Result
            .AsEnumerable()
            .GroupBy(x => x.PickUpDate.Month)
            .Select(group => new
            {
                Month = group.Key.ToString(),
                Revenue = group.Sum(x => x.TotalPrice)
            })
            .OrderBy(x => x.Month)
            .ToList();
        
        var months = revenueByMonth.Select(x => x.Month).ToArray();
        var revenues = revenueByMonth.Select(x => x.Revenue).ToArray();

        return Json(new { Months = months, Revenues = revenues });
    }
    
    public IActionResult RevenueWeeklyChart()
    {
        var revenueByWeek = _reservationService.GetAllAsync().Result
            .AsEnumerable()
            .GroupBy(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                new DateTime(x.PickUpDate.Year, x.PickUpDate.Month, x.PickUpDate.Day),
                CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
            .Select(group => new
            {
                Week = group.Key.ToString(),
                Revenue = group.Sum(x => x.TotalPrice)
            })
            .OrderBy(x => x.Week)
            .ToList();

        var weeks = revenueByWeek.Select(x => x.Week).ToArray();
        var revenues = revenueByWeek.Select(x => x.Revenue).ToArray();

        return Json(new { Weeks = weeks, Revenues = revenues });
    }
    
    public IActionResult RevenueDailyChart()
    {
        var revenueByDayOfWeek = _reservationService.GetAllAsync().Result
            .GroupBy(x => x.PickUpDate.DayOfWeek)
            .Select(group => new
            {
                DayOfWeekNumber = (int)group.Key,
                Revenue = group.Sum(x => x.TotalPrice)
            })
            .OrderBy(x => x.DayOfWeekNumber)
            .ToList();

        var daysOfWeekNumbers = revenueByDayOfWeek.Select(x => x.DayOfWeekNumber).ToArray();
        var revenues = revenueByDayOfWeek.Select(x => x.Revenue).ToArray();

        return Json(new { DayOfWeek = daysOfWeekNumbers, Revenues = revenues });
    }




}