using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Services.Interfaces
{
    public interface IBlogPostService
    {
        public Guid CreateBlogPost(BlogPostCreateDto blogPostCreate);
        public List<BlogPost> GetAllBlogPosts();
        public BlogPost GetBlogPostById(Guid id);
        public List<BlogPost> GetBlogPostsByAuthorUserName(string authorUserName);
        public string UpdateBlogPost(Guid id, string title, string content);
        public string DeleteBlogPost(Guid id);
    }
}
