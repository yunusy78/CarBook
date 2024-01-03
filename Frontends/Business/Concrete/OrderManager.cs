using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Business.Abstract;
using CarBook.Dto.Dtos.Order;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public OrderManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrderDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}");
        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var orderDtos = await response.Content.ReadFromJsonAsync<List<OrderDto>>();
        return orderDtos!;
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var orderDto = await response.Content.ReadFromJsonAsync<OrderDto>();
        return orderDto!;
    }

    public Task<List<OrderDto>> GetListByFilterAsync(Expression<Func<OrderDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto> Checkout(StripeRequestDto stripeRequestDto, string accessToken)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        
        // Construct the request URL
        var requestUrl = $"{serviceApiSettings.BaseUri}/{serviceApiSettings.Order.Path}/CreateStripeSession";

        // Create a new HttpRequestMessage with POST method
        var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);

        // Add the Authorization header with the access token
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        // Serialize your StripeRequestDto to JSON and include it in the request body
        var jsonContent = new StringContent(JsonConvert.SerializeObject(stripeRequestDto), Encoding.UTF8, "application/json");
        request.Content = jsonContent;

        // Send the request and receive the response
        var response = await client.SendAsync(request);

        // Check if the request was successful
        if (!response.IsSuccessStatusCode)
        {
            // Handle the error if needed
            return null;
        }

        // Deserialize the response content to your ResponseDto
        var orderDto = await response.Content.ReadFromJsonAsync<ResponseDto>();

        return orderDto;
        
        
    }

    public async Task<ResponseDto> Confirmation(int orderId)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}/ValidateStripeSession/{orderId}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var orderDto = await response.Content.ReadFromJsonAsync<ResponseDto>();
        return orderDto!;
    }
}