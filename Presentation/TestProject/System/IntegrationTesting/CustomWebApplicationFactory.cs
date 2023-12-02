using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Moq;

namespace TestProject.System.IntegrationTesting;

public class CustomWebApplicationFactory:WebApplicationFactory<Program>
{
    
      public Mock<IMediator> MockContactService { get; }
      
      public CustomWebApplicationFactory()
      {
          MockContactService = new Mock<IMediator>();
      }
      
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureTestServices(services =>
        {
            services.AddScoped(x => MockContactService.Object);
        });
    }
   
}