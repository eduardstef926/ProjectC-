using Microsoft.EntityFrameworkCore;

namespace WebApplication14.Models
{
    public class TopicController: DbContext
    {

        public TopicController(DbContextOptions<TopicController> context) : base(context)
        {

        }
        public DbSet<Topics> Topics { get; set; }
    }
}
