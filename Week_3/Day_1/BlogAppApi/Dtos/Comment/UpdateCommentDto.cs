namespace BlogAppApi.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
    }
}