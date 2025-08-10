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
        public ActionResult<Guid> CreateAuthor([FromBody] AuthorCreateDto author)
        {
            var createAuthorId = _authorService.CreateAuthor(author);
            if(createAuthorId == Guid.Empty)
            {
                return NotFound("Author creation failed.");
            }
            return Ok(createAuthorId);

        }

        [HttpGet("GetAllAuthor")]
        public ActionResult<List<Author>> GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            if(authors.Count == 0)
            {
                return NotFound("No authors found.");
            }
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{authorId:guid}")]
        public ActionResult<Author> GetAuthorById(Guid id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok(author);
        }

        [HttpGet("GetAuthorByUserName/{userName}")]
        public ActionResult<Author> GetAuthorByUserName(string userName)
        {
            var author = _authorService.GetAuthorByUserName(userName);
            if (author == null)
            {
                return NotFound($"Author with username {userName} not found.");
            }
            return Ok(author);
        }

        [HttpPatch("UpdateAuthorUserName/{authorId:guid}/{newUserName}")]
        public ActionResult<string> UpdateAuthor(Guid id, string newUserName)
        {
            var updateMesssage = _authorService.UpdateAuthorUserName(id,newUserName);
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
