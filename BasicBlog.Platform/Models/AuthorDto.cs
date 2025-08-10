namespace BasicBlog.Platform.Models
{
    public class AuthorCreateDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
    }

    public class AuthorUserNameUpdateDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
