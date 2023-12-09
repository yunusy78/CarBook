using System.Linq.Expressions;
using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.FeatureDto;
using CarBook.Dto.Services;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    
    public FeatureManager(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings =  _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return  false;
    }

    public async Task<List<FeatureDto>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<FeatureDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public async Task<FeatureDto> GetByIdAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<FeatureDto>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}/{id}");
        if (response == null)
        {
            return null;
        }
        return response;
        
    }

    public async Task<List<FeatureDto>> GetListByFilterAsync(Expression<Func<FeatureDto, bool>> filter)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<FeatureDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}");
        return response;
        
    }

    public async Task<bool> AddAsync(FeatureDto entity)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
    }

    public async Task<bool> UpdateAsync(FeatureDto entity)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}