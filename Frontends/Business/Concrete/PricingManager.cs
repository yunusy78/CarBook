using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.PricingDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class PricingManager : IPricingService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public PricingManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Pricing.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
        
    }

    public async Task<List<PricingDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Pricing.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var carCategories = JsonConvert.DeserializeObject<List<PricingDto>>(jsonContent);
            return carCategories!;
        }
        return null;
        
    }

    public async Task<PricingDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Pricing.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var pricing = JsonConvert.DeserializeObject<PricingDto>(jsonContent.Result);
            return pricing!;
        }
        return null;
        
    }

    public Task<List<PricingDto>> GetListByFilterAsync(Expression<Func<PricingDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(PricingDto pricingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Pricing.Path}", pricingDto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(PricingDto pricingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Pricing.Path}", pricingDto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
        
    }
}