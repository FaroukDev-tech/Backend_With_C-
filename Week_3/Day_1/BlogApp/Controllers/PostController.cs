using BlogApp.Data;
using BlogApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController(ApiDbContext context) : ControllerBase
    {
        private readonly ApiDbContext _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _context.Posts.ToList().Select(s=>s.ToPostDto());
            return Ok(posts);
        }
    }
}