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
                return NotFound("Blog Post creation failed");
            }
            return Ok(blogPostId);
        }

        [HttpGet("GetAllBlogPost")]
        public ActionResult<List<BlogPost>> GetAllBlogPosts()
        {
            var blogPosts = _blogPostService.GetAllBlogPosts();
            if(blogPosts.Count == 0)
            {
                return NotFound("No blog posts found.");
            }
            return Ok(blogPosts);
        }

        [HttpGet("GetBlogPostById/{blogPostId:guid}")]
        public ActionResult<BlogPost> GetBlogPostById(Guid id)
        {
            var blogPost = _blogPostService.GetBlogPostById(id);
            if (blogPost == null)
            {
                return NotFound($"Blog post with ID {id} not found.");
            }
            return Ok(blogPost);
        }

        [HttpGet("GetBlogPostsByAuthorUserName/{authorUserName}")]
        public ActionResult<List<BlogPost>> GetBlogPostsByAuthorUserName(string authorUserName)
        {
            var blogPosts = _blogPostService.GetBlogPostsByAuthorUserName(authorUserName);
            if (blogPosts.Count == 0)
            {
                return NotFound("No blog posts found for the specified author.");
            }
            return Ok(blogPosts);
        }

        [HttpPatch("UpdateBlogPost/{blogPostId:guid}/{newTitle}/{newContent}")]
        public ActionResult<string> UpdateBlogPost(Guid blogPostId, string newTitle, string newContent)
        {
            var updateMessage = _blogPostService.UpdateBlogPost(blogPostId,newTitle,newContent);
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
