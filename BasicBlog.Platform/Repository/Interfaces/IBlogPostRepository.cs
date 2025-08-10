using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Repository.Interfaces
{
    public interface IBlogPostRepository
    {
        public Guid CreateBlogPost(BlogPost blogPost);
        public List<BlogPost> GetAllBlogPosts();
        public BlogPost GetBlogPostById(Guid id);
        public List<BlogPost> GetBlogPostsByAuthorUserName(string authorUserName);
        public string UpdateBlogPost(Guid id, string title, string content);
        public string DeleteBlogPost(Guid id);
    }
}
