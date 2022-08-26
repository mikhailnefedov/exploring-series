using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; } = default!;
    }
}
