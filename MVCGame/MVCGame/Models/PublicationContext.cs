using Microsoft.EntityFrameworkCore;

namespace MVCGame.Models
{
    public class PublicationContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        public PublicationContext(DbContextOptions<PublicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
