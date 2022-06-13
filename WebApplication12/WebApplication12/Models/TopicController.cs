using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Models
{
    public class TopicController:DbContext
    {

        public TopicController(DbContextOptions<TopicController> context) : base(context)
        {

        }
        public DbSet<Topic> WebsiteDetails { get; set; }
    }
}
