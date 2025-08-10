using BasicBlog.Platform.Models;
using BasicBlog.Platform.Repository.Interfaces;
using BasicBlog.Platform.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

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
            var dto = new BlogPostCreateDto()
            {
                Title = blogPostCreate.Title,
                Content = blogPostCreate.Content,
                AuthorId = blogPostCreate.AuthorId
            };
            var author = _authorRepository.GetAuthorById(dto.AuthorId);
            if (author == null)
            {
                return Guid.Empty;
            }
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
            return blogPosts;
        }
        public BlogPost GetBlogPostById(Guid id)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);
            return blogPost;
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
