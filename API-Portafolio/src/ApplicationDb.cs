using Microsoft.EntityFrameworkCore;
using Proyects.Models;
using UserProyects.Models;
using Users.Models;

namespace ApplicationDb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Proyect> Proyects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyect>()
                .Property(p => p.Name)
                .HasColumnType("varchar");

            modelBuilder.Entity<Proyect>()
                .Property(p => p.Url)
                .HasColumnType("varchar");

            modelBuilder.Entity<Proyect>()
                .Property(p => p.Image)
                .HasColumnType("varchar");

            modelBuilder.Entity<UserProyect>()
                .HasKey(sc => new { sc.UserId, sc.ProyectsId });

            modelBuilder.Entity<UserProyect>()
                .HasOne(sc => sc.User)
                .WithMany(u => u.UserProyects)
                .HasForeignKey(sc => sc.ProyectsId);

            modelBuilder.Entity<UserProyect>()
                .HasOne(sc => sc.Proyects)
                .WithMany(u => u.UserProyects)
                .HasForeignKey(sc => sc.UserId);
        }
    }
}
