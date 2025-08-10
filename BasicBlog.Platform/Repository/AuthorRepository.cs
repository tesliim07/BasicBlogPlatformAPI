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
            if(authors.Count() == 0)
            {
                _logger.LogInformation("No authors found, [AuthorRepository]");
                return new List<Author>();
            }
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
        public Author GetAuthorByUserName(string userName)
        {
            var author = _blogPlatformDbContext.Authors
                .FirstOrDefault(author => author.UserName == userName);
            if (author == null)
            {
                _logger.LogInformation("Invalid UserName, [AuthorRepository]");
                return null;
            }
            return author;
        }
        public string UpdateAuthorUserName(Guid id, string newUserName)
        {
            var author = GetAuthorById(id);
            if(author == null)
            {
                _logger.LogInformation("Unable to update Author username due to invalid Id");
                return "Update was unsuccessful";
            }
            author.UserName = newUserName;
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
