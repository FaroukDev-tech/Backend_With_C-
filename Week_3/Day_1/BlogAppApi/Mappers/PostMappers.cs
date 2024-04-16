using BlogAppApi.Dtos.Post;
using BlogAppApi.Models;

namespace BlogAppApi.Mappers
{
    public static class PostMappers
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                PostId = postModel.PostId,
                Title = postModel.Title,
                Content = postModel.Content,
                CreatedAt = postModel.CreatedAt
            };
        }

        public static Post ToPostDtoFromCreateDto (this CreatePostRequestDto createPostRequestDto)
        {
            return new Post
            {
                PostId = createPostRequestDto.PostId,
                Title = createPostRequestDto.Title,
                Content = createPostRequestDto.Content,
                CreatedAt = createPostRequestDto.CreatedAt
            };
        }
    }
}
