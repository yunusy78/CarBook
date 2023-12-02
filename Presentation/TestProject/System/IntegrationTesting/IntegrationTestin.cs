using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;

namespace TestProject.System.IntegrationTesting;

public class IntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public IntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTestimonials_ShouldReturnSuccessStatusCode()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/api/testimonials");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetTestimonialById_ExistingId_ShouldReturnSuccessStatusCode()
    {
        // Arrange
        var existingTestId = 2; // Replace with a valid existing ID in your system

        // Act
        var response = await _client.GetAsync($"/api/testimonials/{existingTestId}");

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
    
}

