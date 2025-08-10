using BasicBlog.Platform.context;
using BasicBlog.Platform.Models;
using BasicBlog.Platform.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BasicBlog.Platform.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private BlogPlatformDbContext _blogPlatformDbContext;
        private readonly ILogger<BlogPostRepository> _logger;
        public BlogPostRepository(BlogPlatformDbContext blogPlatformDbContext, ILogger<BlogPostRepository> logger)
        {
            _blogPlatformDbContext = blogPlatformDbContext;
            _logger = logger;
        }

        public Guid CreateBlogPost(BlogPost blogPost)
        {
            _blogPlatformDbContext.BlogPosts.Add(blogPost);
            _blogPlatformDbContext.SaveChanges();
            return blogPost.Id;
        }
        public List<BlogPost> GetAllBlogPosts()
        {
            var blogPosts = _blogPlatformDbContext.BlogPosts.Include(p => p.Author).OrderBy(blogPost => blogPost.Id).ToList();
            if (blogPosts.Count == 0)
            {
                _logger.LogInformation("No blog posts found, [BlogPost Repository]");
                return new List<BlogPost>();
            }
            return blogPosts;
        }
        public BlogPost GetBlogPostById(Guid id)
        {
            var blogPost = _blogPlatformDbContext.BlogPosts.Include(p => p.Author).FirstOrDefault(blogPost => blogPost.Id == id);
            if (blogPost == null)
            {
                _logger.LogInformation("Invalid Id, [BlogPost Repository]");
                return null;
            }
            return blogPost;
        }
        public List<BlogPost> GetBlogPostsByAuthorUserName(string authorUserName)
        {
            if (string.IsNullOrEmpty(authorUserName))
            {
                _logger.LogInformation("Author username cannot be null or empty, [BlogPost Repository]");
                return new List<BlogPost>();
            }
            List<BlogPost> blogPosts = _blogPlatformDbContext.BlogPosts.Include(p => p.Author.UserName == authorUserName).OrderByDescending(blogPost => blogPost.DateCreated).ToList();
            if (blogPosts.Count() == 0)
            {
                _logger.LogInformation("Invalid Id, [BlogPost Repository]");
                return new List<BlogPost>();
            }
            return blogPosts;
        }
        public string UpdateBlogPost(Guid id, string title, string content)
        {
            var blogPost = GetBlogPostById(id);
            if (blogPost == null)
            {
                _logger.LogInformation($"Unable to update BlogPost due to invalid Id: {id}, [BlogPost Repository]");
                return "Update was unsuccessful";
            }
            if (DateTime.Now.Subtract(blogPost.DateCreated) >= new System.TimeSpan(0,0,10,0,0,0))
            {
                return "Update was unsuccessful, blog post is older than 10 minutes";
            }
            if (title.Trim() == "" || content.Trim() == "")
            {
                _logger.LogInformation("Title or content cannot be empty, [BlogPost Repository]");
                return "Update was unsuccessful";
            }
            blogPost.Content = content.Trim();
            blogPost.Title = title.Trim();
            _blogPlatformDbContext.BlogPosts.Update(blogPost);
            _blogPlatformDbContext.SaveChanges();
            return "Update was successful";
        }
        public string DeleteBlogPost(Guid id)
        {
            var blogPost = GetBlogPostById(id);
            if (blogPost == null)
            {
                _logger.LogInformation($"Delete was unsuccessful due to invalid Id: {id}, [BlogPost Repository]");
                return "Delete was unsuccessful";
            }
            _blogPlatformDbContext.BlogPosts.Remove(blogPost);
            _blogPlatformDbContext.SaveChanges();
            return "Delete was successful";
        }
    }
}
