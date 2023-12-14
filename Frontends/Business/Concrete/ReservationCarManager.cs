using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.ReservationDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class ReservationCarManager : IReservationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public ReservationCarManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<List<GetReservationCarDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var reservationCars = JsonConvert.DeserializeObject<List<GetReservationCarDto>>(jsonContent);
            return reservationCars!;
        }
        return null;
    }

    public async Task<GetReservationCarDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var reservationCar = JsonConvert.DeserializeObject<GetReservationCarDto>(jsonContent.Result);
            return reservationCar!;
        }
        return null;
    }

    public async Task<List<GetReservationCarDto>> GetListByFilterAsync(Expression<Func<GetReservationCarDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}/{filter}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var reservationCars = JsonConvert.DeserializeObject<List<GetReservationCarDto>>(jsonContent);
            return reservationCars!;
        }
        return null;
    }

    public async Task<bool> CreateReservationAsync(CreateReservationDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}", dto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
        
    }

    public async Task<bool> UpdateReservationAsync(UpdateReservationDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}", dto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
        


    }

    public async Task<List<GetReservationCarDto>> GetReservationCarWithCarAndLocationAndStatusAndPricingAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ReservationCar.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var reservationCars = JsonConvert.DeserializeObject<List<GetReservationCarDto>>(jsonContent);
            return reservationCars!;
        }
        return null;
    }

    public Task<List<GetReservationCarDto>> GetByFilterAsync(Expression<Func<GetReservationCarDto, bool>> filter)
    {
        throw new NotImplementedException();
    }
}