using BasicBlog.Platform.Models;

namespace BasicBlog.Platform.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        public Guid CreateAuthor(Author author);
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(Guid id);
        public string UpdateAuthor(Guid id, string userName);
        public string DeleteAuthor(Guid id);
    }
}
