using BlogAppApi.Mappers;
using BlogAppApi.Data;
using Microsoft.AspNetCore.Mvc;
using BlogAppApi.Dtos.Post;
using BlogAppApi.Managers;

namespace BlogAppApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController(ApiDbContext context) : ControllerBase
    {
        private readonly PostManager postManager = new (context);
        private readonly ApiDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await postManager.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await postManager.GetById(id);

            return Ok(post.ToPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto createPostRequestDto)
        {
            var postModel = await postManager.Create(createPostRequestDto);
            return CreatedAtAction(nameof(GetById), new {id=postModel.PostId}, postModel.ToPostDto());
        }

        [HttpPut]
        [Route("{id}/update")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto updatePostRequestDto)
        {
            var postModel = await postManager.Update(id, updatePostRequestDto);
            return Ok(postModel.ToPostDto());
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await postManager.Delete(id);

            return NoContent();
        }
    }
}