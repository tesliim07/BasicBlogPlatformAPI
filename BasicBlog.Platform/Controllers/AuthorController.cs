using BasicBlog.Platform.Models;
using BasicBlog.Platform.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicBlog.Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("CreateAuthor")]
        public ActionResult<Guid> CreateAuthor([FromBody] Author author)
        {
            var createAuthorId = _authorService.CreateAuthor(author);
            return Ok(createAuthorId);

        }

        [HttpGet("GetAllAuthor")]
        public ActionResult<List<Author>> GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{id:guid}")]
        public ActionResult<Author> GetAuthorById(Guid id)
        {
            var author = _authorService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPatch("UpdateAuthor/{id:guid}/{userName}")]
        public ActionResult<string> UpdateAuthor(Guid id, string userName)
        {
            var updateMesssage = _authorService.UpdateAuthor(id,userName);
            return Ok(updateMesssage);
        }

        [HttpDelete("DeleteAuthor/{id:guid}")]
        public ActionResult<string> DeleteAuthor(Guid id)
        {
            var deleteMessage = _authorService.DeleteAuthor(id);
            return Ok(deleteMessage);
        }
        
    }
}
