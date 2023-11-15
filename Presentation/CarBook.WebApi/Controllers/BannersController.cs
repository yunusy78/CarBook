using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly DeleteBannerCommandHandler _deleteBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        
        
        public BannersController(GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, DeleteBannerCommandHandler deleteBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler)
        {
            _getBannerQueryHandler = getBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _deleteBannerCommandHandler = deleteBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var banners = await _getBannerQueryHandler.Handle();
            return Ok(banners);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(banner);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateBannerCommand request)
        {
            await _createBannerCommandHandler.Handle(request);
            return Ok("Banner created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateBannerCommand request)
        {
            await _updateBannerCommandHandler.Handle(request);
            return Ok("Banner updated successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteBannerCommand(id);
            await _deleteBannerCommandHandler.Handle(request);
            return Ok("Banner deleted successfully");
        }
        
        
        
        
        
    }
}
