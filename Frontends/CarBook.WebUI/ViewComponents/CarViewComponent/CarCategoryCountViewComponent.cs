﻿using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarViewComponent;

public class CarCategoryCountViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;

    public CarCategoryCountViewComponent(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/withCategoryCount");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BlogCategoryCountDto>>(jsonContent);
            return View(values);
        }
        return View();
    }
}