﻿namespace CarBook.Dto.Services;

public class ServiceApiSettings
{
    public string BaseUri { get; set; }
    
    public ServiceApi About { get; set; }
    public ServiceApi Testimonial { get; set; }
    
    public ServiceApi Service { get; set; }
    
    public ServiceApi Car { get; set; }
    
    public ServiceApi Category { get; set; }
    
    public ServiceApi Brand { get; set; }
    
    public ServiceApi Location { get; set; }
    
    public ServiceApi Contact { get; set; }
    
    public ServiceApi Footer { get; set; }
    
    public ServiceApi Banner { get; set; }
    
    public ServiceApi Blog { get; set; }
    
    public ServiceApi BlogCategory { get; set; }
    
    public ServiceApi TagCloud { get; set; }
    
    public ServiceApi Comment { get; set; }
    
}


public class ServiceApi
{
    public string Path { get; set; }
    
    
}