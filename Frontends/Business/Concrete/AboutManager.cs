using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.AboutDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class AboutManager : IAboutService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public AboutManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<AboutDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var AboutDtos = await response.Content.ReadFromJsonAsync<List<AboutDto>>();
        return AboutDtos!;
    }

    public async Task<AboutDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var AboutDto = await response.Content.ReadFromJsonAsync<AboutDto>();
        return AboutDto!;
    }

    public async Task<List<AboutDto>> GetListByFilterAsync(Expression<Func<AboutDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var AboutDtos = await response.Content.ReadFromJsonAsync<List<AboutDto>>();
        return AboutDtos!;


    }

    public async Task<bool> AddAsync(AboutDto aboutDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}", aboutDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(AboutDto aboutDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}", aboutDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}