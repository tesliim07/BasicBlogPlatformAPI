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

        //public Author GetAuthorById(Guid id)
        //{
        //    var author = _blogPlatformDbContext.Authors
        //        .FirstOrDefault(author => author.Id == id);
        //    if (author == null)
        //    {
        //        _logger.LogInformation("Invalid Id, [AuthorRepository]");
        //        return null;
        //    }
        //    return author;
        //}

        public Guid CreateBlogPost(BlogPost blogPost)
        {
            _blogPlatformDbContext.BlogPosts.Add(blogPost);
            _blogPlatformDbContext.SaveChanges();
            return blogPost.Id;

        }
        public List<BlogPost> GetAllBlogPosts()
        {
            var blogPosts = _blogPlatformDbContext.BlogPosts.Include(p => p.Author).OrderBy(blogPost => blogPost.Id).ToList();
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
        public string UpdateBlogPost(Guid id, string title, string content)
        {
            var blogPost = GetBlogPostById(id);
            if (blogPost == null)
            {
                _logger.LogInformation($"Unable to update BlogPost due to invalid Id: {id}, [BlogPost Repository]");
                return "Update was unsuccessful";
            }
            if (title.Trim() != "")
            {
                blogPost.Title = title.Trim();
            }
            if (content.Trim() != "")
            {
                blogPost.Content = content.Trim();
            }
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
