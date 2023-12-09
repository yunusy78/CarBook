using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class LocationManager : ILocationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public LocationManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<LocationDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var locationDtos = await response.Content.ReadFromJsonAsync<List<LocationDto>>();
        return locationDtos!;
    }

    public async Task<LocationDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var locationDto = await response.Content.ReadFromJsonAsync<LocationDto>();
        return locationDto!;
    }

    public async Task<List<LocationDto>> GetListByFilterAsync(Expression<Func<LocationDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var locationDtos = await response.Content.ReadFromJsonAsync<List<LocationDto>>();
        return locationDtos!;


    }

    public async Task<bool> AddAsync(LocationDto locationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}", locationDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(LocationDto locationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}", locationDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}