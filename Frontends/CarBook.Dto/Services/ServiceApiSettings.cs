namespace CarBook.Dto.Services;

public class ServiceApiSettings
{
    public string BaseUri { get; set; }
    
    public ServiceApi About { get; set; }
    public ServiceApi Testimonial { get; set; }
    
    public ServiceApi Service { get; set; }
    
    public ServiceApi Car { get; set; }
    
}


public class ServiceApi
{
    public string Path { get; set; }
    
    
}