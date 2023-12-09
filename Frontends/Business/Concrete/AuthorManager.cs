using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.AuthorDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class AuthorManager : IAuthorService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    
    public AuthorManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Author.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Author.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var carCategories = JsonConvert.DeserializeObject<List<AuthorDto>>(jsonContent);
            return carCategories!;
        }
        return null;
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Author.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var Author = JsonConvert.DeserializeObject<AuthorDto>(jsonContent);
            return Author!;
        }
        return null;
        
    }

    public Task<List<AuthorDto>> GetListByFilterAsync(Expression<Func<AuthorDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(AuthorDto categoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Author.Path}", categoryDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdateAsync(AuthorDto categoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Author.Path}", categoryDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
}