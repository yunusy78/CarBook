using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler  _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly DeleteBrandCommandHandler _deleteBrandCommandHandler;
        
        
        
        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, 
            GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
            CreateBrandCommandHandler createBrandCommandHandler, 
            UpdateBrandCommandHandler updateBrandCommandHandler, 
            DeleteBrandCommandHandler deleteBrandCommandHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _deleteBrandCommandHandler = deleteBrandCommandHandler;
        }
        
       
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var banners = await _getBrandQueryHandler.Handle();
            return Ok(banners);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(banner);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateBrandCommand request)
        {
            await _createBrandCommandHandler.Handle(request);
            return Ok("Brand created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateBrandCommand request)
        {
            await _updateBrandCommandHandler.Handle(request);
            return Ok("Brand updated successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteBrandCommand(id);
            await _deleteBrandCommandHandler.Handle(request);
            return Ok("Brand deleted successfully");
        }
        
    }
}
