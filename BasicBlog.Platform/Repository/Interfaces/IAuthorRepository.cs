using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        public Guid CreateAuthor(Author author);
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(Guid id);
        public Author GetAuthorByUserName(string userName);
        public string UpdateAuthorUserName(Guid id, string newUserName);
        public string DeleteAuthor(Guid id);
    }
}
