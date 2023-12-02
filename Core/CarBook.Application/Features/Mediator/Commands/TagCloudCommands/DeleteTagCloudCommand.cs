using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands;

public class DeleteTagCloudCommand : IRequest
{
        
        public int TagCloudId { get; set; }
    
        
        public DeleteTagCloudCommand(int tagCloudId)
        {
            TagCloudId = tagCloudId;
            
        }
    
    
    
    
    
}