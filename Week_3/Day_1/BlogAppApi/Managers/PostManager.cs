using BlogAppApi.Mappers;
using BlogAppApi.Data;
using BlogAppApi.Dtos.Post;
using BlogAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApi.Managers
{
    public class PostManager(ApiDbContext context)
    {
        private readonly ApiDbContext _context = context;

        public async Task<List<Post>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetById(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p=>p.PostId==id) ?? throw new Exception("Invalid Id. Does not exist");
            return post; 
        }

        public async Task<Post> Create(CreatePostRequestDto createPostRequestDto)
        {
            var postModel = createPostRequestDto.ToPostDtoFromCreateDto();
            _context.Posts.Add(postModel);
            _ = await _context.SaveChangesAsync();

            return postModel;
        }

        public async Task<Post> Update(int id, UpdatePostRequestDto updatePostRequestDto)
        {
            var postModel = await _context.Posts.FirstOrDefaultAsync(x=>x.PostId==id) ?? throw new Exception("Invalid Id. Does not exist");

            postModel.Title = updatePostRequestDto.Title;
            postModel.Content = updatePostRequestDto.Content;
            postModel.CreatedAt = updatePostRequestDto.CreatedAt;

            _ = await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task Delete(int id)
        {
            var postModel = await _context.Posts.FirstOrDefaultAsync(x=>x.PostId==id) ?? throw new Exception("Invalid Id. Does not exist");
            _context.Posts.Remove(postModel);
            _ = await _context.SaveChangesAsync();
        }
    }
}