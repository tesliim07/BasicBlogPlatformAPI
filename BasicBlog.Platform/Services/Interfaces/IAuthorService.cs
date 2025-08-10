using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Services.Interfaces
{
    public interface IAuthorService
    {
        public Guid CreateAuthor(AuthorCreateDto author);
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(Guid id);
        public Author GetAuthorByUserName(string userName);
        public string UpdateAuthorUserName(Guid id, string newUserName);
        public string DeleteAuthor(Guid id);
    }
}
