using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Data.Models;

namespace RentACar.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.EGN)
                .IsUnique();


            builder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);


            builder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}