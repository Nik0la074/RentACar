using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Data.Models;

namespace RentACar.Data
{
    /// <summary>
    /// Database context for the Rent A Car application.
    /// Extends IdentityDbContext to support user authentication and authorization.
    /// </summary>
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>Database set for cars.</summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>Database set for reservations.</summary>
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ensure EGN is unique across all users
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.EGN)
                .IsUnique();

            // Configure one-to-many relationship between Car and Reservation
            builder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);

            // Configure one-to-many relationship between User and Reservation
            builder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}