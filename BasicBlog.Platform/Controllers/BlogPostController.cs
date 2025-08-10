using BasicBlog.Platform.Models;
using BasicBlog.Platform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicBlog.Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpPost("CreateBlogPost")]
        public ActionResult<Guid> CreateBlogPost(BlogPostCreateDto blogPostCreate)
        {
            var blogPostId = _blogPostService.CreateBlogPost(blogPostCreate);
            if(blogPostId == Guid.Empty)
            {
                return NotFound();
            }
            return Ok(blogPostId);
        }

        [HttpGet("GetAllBlogPost")]
        public ActionResult<List<BlogPost>> GetBlogPosts()
        {
            var blogPosts = _blogPostService.GetAllBlogPosts();
            return Ok(blogPosts);
        }

        [HttpGet("GetBlogPostById/{id:guid}")]
        public ActionResult<BlogPost> GetBlogPostById(Guid id)
        {
            var blogPost = _blogPostService.GetBlogPostById(id);
            return Ok(blogPost);
        }

        [HttpPatch("UpdateBlogPost/{id:guid}/{title}/{content}")]
        public ActionResult<string> UpdateBlogPost(Guid id, string title, string content)
        {
            var updateMessage = _blogPostService.UpdateBlogPost;
            return Ok(updateMessage);
        }

        [HttpDelete("DeleteBlogPost/{id:guid}")]
        public ActionResult<string> DeleteBlogPost(Guid id)
        {
            var deleteMessage = _blogPostService.DeleteBlogPost(id);
            return Ok(deleteMessage);
        }
    }
}
