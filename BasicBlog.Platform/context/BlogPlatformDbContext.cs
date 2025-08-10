using BasicBlog.Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicBlog.Platform.context
{
    public class BlogPlatformDbContext(DbContextOptions<BlogPlatformDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    }
}
