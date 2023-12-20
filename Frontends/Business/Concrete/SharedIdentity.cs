﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class SharedIdentity : ISharedIdentity
{
    private IHttpContextAccessor _httpContextAccessor;
    
    public SharedIdentity(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value;
    
    public string Name => _httpContextAccessor.HttpContext.User.FindFirst("name")?.Value;
}