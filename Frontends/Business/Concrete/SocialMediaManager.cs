using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using CarBook.Dto.Dtos.SocialMediaDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public SocialMediaManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
    }

    public async Task<List<SocialMediaDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}");
        if (response.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<List<SocialMediaDto>>(await response.Content.ReadAsStringAsync());
            return result;
        }
        
        return null;
    }

    public async Task<SocialMediaDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<SocialMediaDto>(await response.Content.ReadAsStringAsync());
            return result;
        }
        
        return null;
    }

    public Task<List<SocialMediaDto>> GetListByFilterAsync(Expression<Func<SocialMediaDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(SocialMediaDto socialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(socialMediaDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}", data);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
        
    }

    public async Task<bool> UpdateAsync(SocialMediaDto socialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(socialMediaDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}", data);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
    }
}