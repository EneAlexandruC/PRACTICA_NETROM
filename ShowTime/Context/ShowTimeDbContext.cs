using Microsoft.EntityFrameworkCore;
using ShowTime.Entities;

namespace ShowTime.Context
{
    public class ShowTimeDbContext : DbContext
    {
        public ShowTimeDbContext(DbContextOptions<ShowTimeDbContext> options) : base(options)
        {
        }
        public DbSet<Festival> Festivals { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Band> Bands { get; set; } = null!;
        public DbSet<BandFestival> BandFestivals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Festival>()
                .HasMany(e => e.Bands)
                .WithMany(e => e.Festivals)
                .UsingEntity<BandFestival>();
        }
    }
}
