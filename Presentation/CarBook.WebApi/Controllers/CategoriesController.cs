using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler  _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;
        
        
        
        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, 
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, 
            CreateCategoryCommandHandler createCategoryCommandHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandler, 
            DeleteCategoryCommandHandler deleteCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
        }
        
       
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var banners = await _getCategoryQueryHandler.Handle();
            return Ok(banners);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(category);
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request)
        {
            await _createCategoryCommandHandler.Handle(request);
            return Ok("Category created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateCategoryCommand request)
        {
            await _updateCategoryCommandHandler.Handle(request);
            return Ok("Category updated successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteCategoryCommand(id);
            await _deleteCategoryCommandHandler.Handle(request);
            return Ok("Category deleted successfully");
        }
        
    }
}
