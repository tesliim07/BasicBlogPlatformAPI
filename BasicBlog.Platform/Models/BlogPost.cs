namespace BasicBlog.Platform.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
