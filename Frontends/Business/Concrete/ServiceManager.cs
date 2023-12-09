using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.ServiceDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class ServiceManager : IServiceService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public ServiceManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<ServiceDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var ServiceDtos = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();
        return ServiceDtos!;
    }

    public async Task<ServiceDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var ServiceDto = await response.Content.ReadFromJsonAsync<ServiceDto>();
        return ServiceDto!;
    }

    public async Task<List<ServiceDto>> GetListByFilterAsync(Expression<Func<ServiceDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var ServiceDtos = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();
        return ServiceDtos!;


    }

    public async Task<bool> AddAsync(ServiceDto ServiceDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}", ServiceDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(ServiceDto ServiceDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}", ServiceDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}