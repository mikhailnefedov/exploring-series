using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; } = default!;
    }
}
