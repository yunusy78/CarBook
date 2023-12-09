using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public BrandManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var brandDtos = await response.Content.ReadFromJsonAsync<List<BrandDto>>();
        return brandDtos!;
    }

    public Task<BrandDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}/{id}");
        if (!response.Result.IsSuccessStatusCode)
        {
            return null;
        }
        var brandDto = response.Result.Content.ReadFromJsonAsync<BrandDto>();
        return brandDto!;
    }

    public Task<List<BrandDto>> GetListByFilterAsync(Expression<Func<BrandDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}");
        if (!response.Result.IsSuccessStatusCode)
        {
            return null;
        }
        var brandDtos = response.Result.Content.ReadFromJsonAsync<List<BrandDto>>();
        return brandDtos!;
        
    }

    public async Task<bool> AddAsync(BrandDto entity)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdateAsync(BrandDto entity)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}