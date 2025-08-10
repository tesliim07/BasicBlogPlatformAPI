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

        public Guid CreateAuthor(AuthorCreateDto author)
        {
            if (author == null || author.UserName.Trim()== "" || author.Email.Trim() == "" || author.DateOfBirth > new DateOnly(2013,1,1))
            {
                _logger.LogInformation("Author creation failed due to empty fields, [AuthorService]");
                return Guid.Empty;
            }
            var dto = new AuthorCreateDto()
            {
                UserName = author.UserName,
                Email = author.Email,
                DateOfBirth = author.DateOfBirth
            };
            var newAuthor = new Author(){
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth
            };
            var authorId = _authorRepository.CreateAuthor(newAuthor);
            return authorId;
        }
        public List<Author> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            if (authors.Count == 0)
            {
                return new List<Author>();
            }
            return authors;
        }
        public Author GetAuthorById(Guid id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return null;
            }
            return author;
        }
        public Author GetAuthorByUserName(string userName)
        {
            var author = _authorRepository.GetAuthorByUserName(userName);
            if (author == null)
            {
                return null;
            }
            return author;
        }
        public string UpdateAuthorUserName(Guid id, string newUserName)
        {
            var updateMessage = _authorRepository.UpdateAuthorUserName(id, newUserName);
            return updateMessage;
        }
        public string DeleteAuthor(Guid id)
        {
            var deleteMessage = _authorRepository.DeleteAuthor(id);
            return deleteMessage;
        }
    }
}
