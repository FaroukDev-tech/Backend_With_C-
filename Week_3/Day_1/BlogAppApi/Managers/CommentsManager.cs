using BlogAppApi.Data;
using BlogAppApi.Dtos.Comment;
using BlogAppApi.Mappers;
using Microsoft.EntityFrameworkCore;
using BlogAppApi.Models;

namespace BlogAppApi.Managers
{
    public class CommentManager(ApiDbContext context)
    {
        private readonly ApiDbContext _context = context; 

        public async Task<List<Comment>> GetAllComments()
        {
            var comments = await _context.Comments.ToListAsync();

            return comments;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(s => s.CommentId==id) ?? throw new Exception("Not Found. Invalid Id");
            return comment;
        }        

        public async Task<Comment> CreateComment(CreateCommentDto commentDto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId==commentDto.PostId) ?? throw new Exception("Invalid post Id");
            var commentModel = commentDto.ToCommentDtoFromCreateDto();
            post.Comments.Add(commentModel);
            _context.Comments.Add(commentModel);
            _ = await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment> UpdateComment(int id, CreateCommentDto commentDto)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId==id) ?? throw new Exception("Invalid comment Id");
            var commentModel = commentDto.ToCommentDtoFromCreateDto();
            
            comment.CommentId = commentDto.CommentId;
            comment.Text = commentDto.Text;
            comment.CreatedAt = commentDto.CreatedAt;
            comment.PostId = commentDto.PostId;

            _ = await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task DeleteComment(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId==id) ?? throw new Exception("Invalid comment Id");

            _context.Comments.Remove(commentModel);
            _ = await _context.SaveChangesAsync();
        }
    }
}