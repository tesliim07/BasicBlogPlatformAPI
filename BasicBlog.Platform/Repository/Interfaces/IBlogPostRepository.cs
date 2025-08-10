using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Repository.Interfaces
{
    public interface IBlogPostRepository
    {
        //public Author GetAuthorById(Guid id);
        public Guid CreateBlogPost(BlogPost blogPost);
        public List<BlogPost> GetAllBlogPosts();
        public BlogPost GetBlogPostById(Guid id);
        public string UpdateBlogPost(Guid id, string title, string content);
        public string DeleteBlogPost(Guid id);
    }
}
