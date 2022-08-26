using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Attendee>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            modelBuilder
                .Entity<SessionAttendee>()
                .HasKey(sa => new { sa.SessionId, sa.AttendeeId });

            modelBuilder
                .Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });
        }

        public DbSet<Speaker> Speakers { get; set; } = default!;
        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<Attendee> Attendees { get; set; } = default!;
    
    }
}
