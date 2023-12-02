using System.Collections.Generic;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject.System.Controller;

public class TestimonialControllerUnitTest 
{
    
    [Fact]
    public async Task GetTestimonials_ShouldReturnOk()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<GetTestimonialQuery>(), default)).ReturnsAsync(new List<GetTestimonialQueryResult>());
        var controller = new TestimonialsController(mediatorMock.Object);

        // Act
        var result = await controller.GetTestimonials();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetTestimonialById_ShouldReturnOk()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<GetTestimonialByIdQuery>(), default)).ReturnsAsync(new GetTestimonialByIdQueryResult());
        var controller = new TestimonialsController(mediatorMock.Object);

        // Act
        var result = await controller.GetTestimonialById(1); // Provide a valid id

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async Task UpdateTestimonial_ShouldReturnOk()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<UpdateTestimonialCommand>(), default)).Returns(Task.CompletedTask);
        var controller = new TestimonialsController(mediatorMock.Object);

        // Act
        var result = await controller.UpdateTestimonial(new UpdateTestimonialCommand());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task DeleteTestimonial_ShouldReturnOk()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<DeleteTestimonialCommand>(), default)).Returns(Task.CompletedTask);
        var controller = new TestimonialsController(mediatorMock.Object);

        // Act
        var result = await controller.DeleteTestimonial(1); // Provide a valid id

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}