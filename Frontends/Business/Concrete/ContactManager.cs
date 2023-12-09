using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.ContactDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class ContactManager : IContactService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    
    public ContactManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Contact.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<ContactDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Contact.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var carCategories = JsonConvert.DeserializeObject<List<ContactDto>>(jsonContent);
            return carCategories!;
        }
        return null;
    }

    public async Task<ContactDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Contact.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var Contact = JsonConvert.DeserializeObject<ContactDto>(jsonContent);
            return Contact!;
        }
        return null;
        
    }

    public Task<List<ContactDto>> GetListByFilterAsync(Expression<Func<ContactDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(ContactDto categoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Contact.Path}", categoryDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdateAsync(ContactDto categoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Contact.Path}", categoryDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
}