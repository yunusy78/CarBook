
using Business.Abstract;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;
using CarBook.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminAssignFeatureController : Controller
{
    
    private readonly IFeatureService _featureService;
    private readonly ICarService _carService;
    private readonly ICarFeatureService _carFeatureService;
    
    public AdminAssignFeatureController(IFeatureService featureService, ICarService carService, ICarFeatureService carFeatureService)
    {
        _featureService = featureService;
        _carService = carService;
        _carFeatureService = carFeatureService;
    }
    
    
    public async Task<IActionResult> CarList()
    {
        var result = await _carService.GetAllAsync();
        return View(result);
    }
    
    public async Task<IActionResult> AssignFeature(int id)
    {
        
        
        var result = await _carService.GetByIdAsync(id);
        TempData["carId"] = result!.CarId;
        var featureList = await _featureService.GetAllAsync();
        var carFeatureList = await _carFeatureService.GetByFilterAsync(id);
        foreach (var item in carFeatureList)
        {
            await _carFeatureService.DeleteAsync(item.CarFeatureId);
        }
        List<FeatureAssignModel> carList = new List<FeatureAssignModel>();
        foreach (var item in featureList)
        {
            FeatureAssignModel model = new FeatureAssignModel();
            model.FeatureId = item.FeatureId;
            model.Name = item.Name;
            model.IsAvailable = carFeatureList.Any(x => x.FeatureId == item.FeatureId);
            carList.Add(model);
        }
        return View(carList);
        
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AssignFeature(List<FeatureAssignModel> assignFeatureModels)
    {
        var carId = (int)TempData["carId"];
    
        foreach (var item in assignFeatureModels)
        {
            if (item.IsAvailable)
            {
                CreateCarFeatureDto dto = new CreateCarFeatureDto();
                dto.CarId = carId;
                dto.FeatureId = item.FeatureId;
                dto.IsAvailable = item.IsAvailable;
                await _carFeatureService.CreateCarAsync(dto);
            }
            else
            {
                CreateCarFeatureDto dto = new CreateCarFeatureDto();
                dto.CarId = carId;
                dto.FeatureId = item.FeatureId;
                dto.IsAvailable = item.IsAvailable;
                await _carFeatureService.CreateCarAsync(dto);
                
            }
            // You might have additional logic for the else case here
        }

        return Redirect("/Admin/AdminAssignFeature/CarList");
    }


    
}