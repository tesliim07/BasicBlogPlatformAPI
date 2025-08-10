using BasicBlog.Platform.Models;
using BasicBlog.Platform.Repository.Interfaces;
using BasicBlog.Platform.Services.Interfaces;

namespace BasicBlog.Platform.Services
{
    public class BlogPostService : IBlogPostService
    {
        private IBlogPostRepository _blogPostRepository;
        private IAuthorRepository _authorRepository;
        private readonly ILogger<BlogPostService> _logger;

        public BlogPostService(IBlogPostRepository blogPostRepository, IAuthorRepository authorRepository, ILogger<BlogPostService> logger)
        {
            _blogPostRepository = blogPostRepository;
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public Guid CreateBlogPost(BlogPostCreateDto blogPostCreate)
        {
            var author = _authorRepository.GetAuthorById(blogPostCreate.AuthorId);
            if (author == null || blogPostCreate.Title.Trim() == "" || blogPostCreate.Content.Trim() == "")
            {
                _logger.LogInformation("Author not found or title/content is empty, [BlogPost Service]");
                return Guid.Empty;
            }
            var dto = new BlogPostCreateDto()
            {
                Title = blogPostCreate.Title,
                Content = blogPostCreate.Content,
                AuthorId = blogPostCreate.AuthorId
            };
            var newBlogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Content = dto.Content,
                DateCreated = DateTime.Now,
                AuthorId = dto.AuthorId,
                Author = author
            };
            var blogPostId = _blogPostRepository.CreateBlogPost(newBlogPost);
            return blogPostId;

        }
        public List<BlogPost> GetAllBlogPosts()
        {
            var blogPosts = _blogPostRepository.GetAllBlogPosts();
            if (blogPosts.Count == 0)
            {
                return new List<BlogPost>();
            }
            return blogPosts;
        }
        public BlogPost GetBlogPostById(Guid id)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);
            if (blogPost == null)
            {
                return null;
            }
            return blogPost;
        }
        public List<BlogPost> GetBlogPostsByAuthorUserName(string authorUserName)
        {
            var blogPosts = _blogPostRepository.GetBlogPostsByAuthorUserName(authorUserName);
            if (blogPosts.Count == 0)
            {
                return new List<BlogPost>();
            }
            return blogPosts;
        }
        public string UpdateBlogPost(Guid id, string title, string content)
        {
            var updateMessage = _blogPostRepository.UpdateBlogPost(id, title, content);
            return updateMessage;
        }
        public string DeleteBlogPost(Guid id)
        {
            var deleteMessage = _blogPostRepository.DeleteBlogPost(id);
            return deleteMessage;
        }
    }
}
