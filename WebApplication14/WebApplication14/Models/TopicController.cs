using Microsoft.EntityFrameworkCore;

namespace WebApplication14.Models
{
    public class TopicController:DbContext
    {
        public TopicController(DbContextOptions<TopicController> options) : base(options)
        { }

        public DbSet<Topic> Topics { get; set; }
    }
}
