namespace BlogApp.Dtos.Post
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}
    }
}