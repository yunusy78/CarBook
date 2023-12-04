using AutoMapper;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.DTOs;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        
        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> GetAllComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            return Ok(comments);
        }
        
        [HttpGet("{id}")]
        
        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return Ok(comment);
        }
        
        [HttpPost]
        
        public async Task<ActionResult<CommentDto>> CreateComment(CommentDto commentDto)
        {
            // CommentDto'yu Comment sınıfına eşle
            var comment = _mapper.Map<Comment>(commentDto);

            // Comment'i kullanarak işlemleri gerçekleştir
           await _commentRepository.AddAsync(comment);

            // İşlem sonucuna göre bir response döndür
            return Ok("Comment created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<ActionResult<CommentDto>> UpdateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.UpdateAsync(comment);
            return Ok(comment);
        }
        
        
        [HttpDelete("{id}")]
        
        public async Task<ActionResult> DeleteComment(int id)
        {
            var request = await _commentRepository.GetByIdAsync(id);
            await _commentRepository.DeleteAsync(request);  
            return Ok("Comment deleted successfully");
        }
        
        [HttpGet("withBlog/{blogId}")]
        
        public async Task<ActionResult<List<CommentDto>>> GetCommentsByBlogId(int blogId)
        {
            var comments = await _commentRepository.GetCommentsByBlogId(blogId);
            return Ok(comments);
        }
       
    }
}
