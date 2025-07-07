using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowTime.Entities;

namespace ShowTime.Context
{
    public class ShowTimeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ShowTimeDbContext(DbContextOptions<ShowTimeDbContext> options) : base(options)
        {
        }
        public DbSet<Festival> Festivals { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Band> Bands { get; set; } = null!;
        public DbSet<BandFestival> BandFestivals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Festival>()
                .HasMany(e => e.Bands)
                .WithMany(e => e.Festivals)
                .UsingEntity<BandFestival>();

            base.OnModelCreating(builder);
        }
    }
}
