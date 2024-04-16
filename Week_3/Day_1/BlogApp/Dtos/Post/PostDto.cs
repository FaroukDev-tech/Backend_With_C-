namespace BlogApp.Dtos.Post
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}
    }
}