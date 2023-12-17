using Business.Abstract;
using CarBook.Dto.Dtos.Statistic;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class StatisticManager : IStatisticService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public StatisticManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    
    public async Task<int> GetCarCount()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetCarCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            var carCount = JsonConvert.DeserializeObject<int>(jsonContent);
            return carCount;
        }
        return 0;
    }

    public async Task<int> GetBrandCount()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage =await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetBrandCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            var brandCount = JsonConvert.DeserializeObject<int>(jsonContent);
            return brandCount;
        }
        return 0;
        
    }

    public async Task<int> GetBlogCount()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetBlogCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            var blogCount = JsonConvert.DeserializeObject<int>(jsonContent);
            return blogCount;
        }
        return 0;
    }

    public async Task<int> GetAuthorCount()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetAuthorCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            var authorCount = JsonConvert.DeserializeObject<int>(jsonContent);
            return authorCount;
        }
        return 0;
    }

    public  async Task<string> GetHighestPriceCar()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetHighestPriceCar");
        if (responseMessage.IsSuccessStatusCode)
        {
            try
            {
                var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Alınan JSON İçeriği: " + jsonContent);
                return jsonContent;
            }
            catch (JsonReaderException ex)
            {
                // Log the exception or handle it appropriately
                // You might want to return a default value or handle the error in a way that makes sense for your application.
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return "DefaultFallbackValue"; // Provide a default value or handle the error accordingly.
            }

        }
        return null;
    }

    public  async Task<string> GetLowestPriceCar()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetLowestPriceCar");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Alınan JSON İçeriği: " + jsonContent);
            return jsonContent;
        
        }
        return null;
        
    }

    public  async Task<string> GetMostRentedCarModel()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetMostRentedCarModel");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Alınan JSON İçeriği: " + jsonContent);
            return jsonContent;
        }
        return null;
    }

    public  async Task<string> GetMinRentedCarModel()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await 
            client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Statistic.Path}/GetMinRentedCarModel");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonContent = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Alınan JSON İçeriği: " + jsonContent);
            return jsonContent;
        }
        return null;
    }
}