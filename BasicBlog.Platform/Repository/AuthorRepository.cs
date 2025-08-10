using BasicBlog.Platform.context;
using BasicBlog.Platform.Models;
using BasicBlog.Platform.Repository.Interfaces;

namespace BasicBlog.Platform.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private BlogPlatformDbContext _blogPlatformDbContext;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(BlogPlatformDbContext blogPlatformDbContext, ILogger<AuthorRepository> logger)
        {
            _blogPlatformDbContext = blogPlatformDbContext;
            _logger = logger;
        }

        public Guid CreateAuthor(Author author)
        {
            _blogPlatformDbContext.Authors.Add(author);
            _blogPlatformDbContext.SaveChanges();
            return author.Id;
        }
        public List<Author> GetAllAuthors()
        {
            var authors = _blogPlatformDbContext.Authors
                .OrderBy(author => author.Id)
                .ToList();
            return authors;

        }
        public Author GetAuthorById(Guid id)
        {
            var author = _blogPlatformDbContext.Authors
                .FirstOrDefault(author => author.Id == id);
            if (author == null)
            {
                _logger.LogInformation("Invalid Id, [AuthorRepository]");
                return null;
            }
            return author;
        }
        public string UpdateAuthor(Guid id, string userName)
        {
            var author = GetAuthorById(id);
            if(author == null)
            {
                _logger.LogInformation("Unable to update Author due to invalid Id");
                return "Update was unsuccessful";
            }
            author.UserName = userName;
            _blogPlatformDbContext.Authors.Update(author);
            _blogPlatformDbContext.SaveChanges();
            return "Update was successful";
        }
        public string DeleteAuthor(Guid id)
        {
            var author = GetAuthorById(id);
            if (author == null)
            {
                _logger.LogInformation("Unable to delete Author due to invalid Id");
                return "Delete was unsuccessful";
            }
            _blogPlatformDbContext.Authors.Remove(author);
            _blogPlatformDbContext.SaveChanges();
            return "Delete was successful";
        }
    }
}
