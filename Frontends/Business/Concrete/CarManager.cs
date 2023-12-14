using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Business.Concrete;

public class CarManager : ICarService 
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    
    public CarManager(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    
    
    public async Task<bool> AddAsync(CreateCarDto entity)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
        
    }
    
    public async Task<bool> UpdateAsync(UpdateCarDto entity)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<List<CarDto>> GetCarWithPriceBy()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/withpricing");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<CarDto>>(jsonContent);
            return value!;
        }
        return null!;
    }

    public async Task<List<CarDto>> GetCarWithLocationAndStatus(int locationId)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/withLocationAndStatus/{locationId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<CarDto>>(jsonContent);
            return value!;
        }
        return null!;
        
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings =  _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
    
    public async Task<List<CarDto>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadFromJsonAsync<List<CarDto>>();
            return jsonContent!;
        }
        return null!;
    }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            var response =  await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadFromJsonAsync<CarDto>();
                return jsonContent.Result!;
            }
            return null!;
        }

        public Task<List<CarDto>> GetListByFilterAsync(Expression<Func<CarDto, bool>> filter)
        {
            throw new NotImplementedException();
        }

    }