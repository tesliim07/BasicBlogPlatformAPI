namespace BasicBlog.Platform.Models
{
    public class BlogPostCreateDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Guid AuthorId { get; set; }
    }
}
