using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.TagCloud;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Business.Concrete;

public class TagCloudManager : ITagCloudService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public TagCloudManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<TagCloudDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var TagCloudDtos = await response.Content.ReadFromJsonAsync<List<TagCloudDto>>();
        return TagCloudDtos!;
    }

    public async Task<TagCloudDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var TagCloudDto = await response.Content.ReadFromJsonAsync<TagCloudDto>();
        return TagCloudDto!;
    }

    public async Task<List<TagCloudDto>> GetListByFilterAsync(Expression<Func<TagCloudDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var TagCloudDtos = await response.Content.ReadFromJsonAsync<List<TagCloudDto>>();
        return TagCloudDtos!;


    }

    public async Task<bool> AddAsync(TagCloudDto tagCloudDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}", tagCloudDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(TagCloudDto tagCloudDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.TagCloud.Path}", tagCloudDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<List<TagCloudDto>> GetByBlogIdAsync(int blogId)
    {
        var apiSetting = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"{apiSetting!.BaseUri}/{apiSetting.TagCloud.Path}/GetTagCloudByBlogId/{blogId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TagCloudDto>>(jsonContent);
            return values!;

        }
        return null;
    }
}