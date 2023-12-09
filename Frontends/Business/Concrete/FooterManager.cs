using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.FooterDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class FooterManager : IFooterService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public FooterManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<FooterDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var FooterDtos = await response.Content.ReadFromJsonAsync<List<FooterDto>>();
        return FooterDtos!;
    }

    public async Task<FooterDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var FooterDto = await response.Content.ReadFromJsonAsync<FooterDto>();
        return FooterDto!;
    }

    public async Task<List<FooterDto>> GetListByFilterAsync(Expression<Func<FooterDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var FooterDtos = await response.Content.ReadFromJsonAsync<List<FooterDto>>();
        return FooterDtos!;


    }

    public async Task<bool> AddAsync(FooterDto FooterDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}", FooterDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(FooterDto FooterDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Footer.Path}", FooterDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}