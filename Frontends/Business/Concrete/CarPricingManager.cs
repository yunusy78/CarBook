using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.CarPricingDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class CarPricingManager : ICarPricingService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public CarPricingManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarPricing.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<List<CarPricingDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarPricing.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var carCategories = JsonConvert.DeserializeObject<List<CarPricingDto>>(jsonContent);
            return carCategories!;
        }
        return null;
    }

    public async Task<CarPricingDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarPricing.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var pricing = JsonConvert.DeserializeObject<CarPricingDto>(jsonContent.Result);
            return pricing!;
        }
        return null;
    }

    public Task<List<CarPricingDto>> GetListByFilterAsync(Expression<Func<CarPricingDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(CreateCarPricingDto entity)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var jsonData = JsonConvert.SerializeObject(entity);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarPricing.Path}", content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(CarPricingDto entity)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var jsonData = JsonConvert.SerializeObject(entity);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarPricing.Path}", content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
    
}