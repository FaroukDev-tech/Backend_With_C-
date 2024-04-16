using BlogAppApi.Data;
using Microsoft.AspNetCore.Mvc;
using BlogAppApi.Dtos.Comment;
using BlogAppApi.Mappers;
using BlogAppApi.Managers;

namespace BlogAppApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController(ApiDbContext context) : ControllerBase
    {
        private readonly CommentManager commentManager = new(context);
        private readonly ApiDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentManager.GetAllComments();
            return Ok(comments);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await commentManager.GetCommentById(id);
            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto commentDto)
        {
            var commentModel = await commentManager.CreateComment(commentDto);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.CommentId}, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCommentDto commentDto)
        {
            var commentModel = await commentManager.UpdateComment(id, commentDto);
            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await commentManager.DeleteComment(id);
            return NoContent();
        }
    }
}