using Microsoft.EntityFrameworkCore;

namespace WebApplication14.Models
{
    public class PostController: DbContext
    {
        public PostController(DbContextOptions<PostController> options): base(options)
        { }

        public DbSet<Posts> Posts { get; set; }
    }
}
