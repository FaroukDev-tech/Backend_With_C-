using BlogAppApi.Models;

namespace BlogAppApi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public Post? Post {get; set;}

        public static implicit operator Comment(HashSet<Comment> v)
        {
            throw new NotImplementedException();
        }
    }
}