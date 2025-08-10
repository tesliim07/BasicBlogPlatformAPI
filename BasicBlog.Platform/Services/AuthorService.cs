using BasicBlog.Platform.Models;
using BasicBlog.Platform.Repository.Interfaces;
using BasicBlog.Platform.Services.Interfaces;

namespace BasicBlog.Platform.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IAuthorRepository authorRepository, ILogger<AuthorService> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public Guid CreateAuthor(Author author)
        {
            var newAuthor = new Author
            {
                Id = Guid.NewGuid(),
                UserName = author.UserName,
                Email = author.Email,
                DateOfBirth = author.DateOfBirth
            };
            var authorId = _authorRepository.CreateAuthor(newAuthor);
            return authorId;
        }
        public List<Author> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return authors;
        }
        public Author GetAuthorById(Guid id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                _logger.LogInformation($"No Author could be gotten from {id}, [AuthorService]");
                return null;
            }
            return author;
        }
        public string UpdateAuthor(Guid id, string userName)
        {
            var updateMessage = _authorRepository.UpdateAuthor(id, userName);
            return updateMessage;
        }
        public string DeleteAuthor(Guid id)
        {
            var deleteMessage = _authorRepository.DeleteAuthor(id);
            return deleteMessage;
        }
    }
}
