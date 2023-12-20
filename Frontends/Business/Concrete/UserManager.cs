﻿using System.Net.Http.Json;
using Business.Abstract;
using CarBook.Dto.Dtos.User;
using CarBook.Dto.Services;
using Microsoft.Extensions.Options;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _serviceApiSettings;
    
    public UserManager(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _serviceApiSettings = serviceApiSettings.Value;
       
    }
    
    public async Task<UserViewModel> GetUser()
    {
        return (await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getUser"))!;
    }
    
    public async Task<List<UserViewModel>> GetAllUser()
    {
        return (await _httpClient.GetFromJsonAsync<List<UserViewModel>>(_serviceApiSettings.IdentityServerAPI + "/api/user/GetAllUsers/GetAllUsers"))!;
    }
}