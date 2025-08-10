namespace BasicBlog.Platform.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
    }

}
