using BlogAppApi.Dtos.Comment;
using BlogAppApi.Models;

namespace BlogAppApi.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto (this Comment commentModel)
        {
            return new CommentDto
            {
                CommentId = commentModel.CommentId,
                Text = commentModel.Text,
                CreatedAt = commentModel.CreatedAt,
                PostId = commentModel.PostId
            };
        }

        public static Comment ToCommentDtoFromCreateDto (this CreateCommentDto commentDto)
        {
            return new Comment
            {
                CommentId = commentDto.CommentId,
                Text = commentDto.Text,
                CreatedAt = commentDto.CreatedAt,
                PostId = commentDto.PostId
            };
        }
    }
}