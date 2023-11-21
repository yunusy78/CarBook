﻿using CarBook.Dto.Dtos.AboutDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class AboutController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration configuration;
    
    public AboutController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        this.configuration = configuration;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        ViewBag.v1 = "Om Oss";
        ViewBag.v2 = "Vår Visjon og Misjon";
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonContent);
            return View(values);
            
        }
        return View();
    }
}