using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.CarFeatureDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using CreateCarFeatureDto = CarBook.Domain.DTOs.CarFeatureDto.CreateCarFeatureDto;
using GetCarFeatureDto = CarBook.Dto.Dtos.CarFeatureDto.GetCarFeatureDto;

namespace Business.Concrete;

public class CarFeatureManager : ICarFeatureService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public CarFeatureManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<GetCarFeatureDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetCarFeatureDto>>(jsonContent);
            return result;
        }
        return null;
    }

    public async Task<GetCarFeatureDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetCarFeatureDto>(jsonContent);
            return result!;
        }
        return null!;
    }

    public Task<List<GetCarFeatureDto>> GetListByFilterAsync(Expression<Func<GetCarFeatureDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateCarAsync(CreateCarFeatureDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}", data);
        if (!response.IsSuccessStatusCode)
        {
            return false;
            
        }
        return true;
        
    }

    public async Task<bool> UpdateCarAsync(UpdateCarFetaureDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}", data);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<GetCarFeatureDto>> GetCarFeatureWithCarAndFeatureAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}/GetCarFeatureWithCarAndFeature");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetCarFeatureDto>>(jsonContent);
            return result!;
        }
        return null!;
    }

    public async Task<List<GetCarFeatureDto>> GetByFilterAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarFeature.Path}/GetByFilter/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetCarFeatureDto>>(jsonContent);
            return result!;
        }
        return null!;
        
    }
}