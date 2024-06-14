using Microsoft.EntityFrameworkCore;
using ProyectImages.Models;
using Proyects.Models;
using Reviews.Model;
using UserProyects.Models;
using Users.Models;

namespace ApplicationDb.Models
{
    public class ApplicationDbContext : DbContext
    {        
        public DbSet<User> Users { get; set; }
        public DbSet<Proyect> Proyects { get; set; }
        public DbSet<UserProyect> UserProyects { get; set; }

        public DbSet<ProyectImage> ProyectImages { get; set;}
        public DbSet<Review> Review { get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProyect>()
                .HasKey(up => new { up.ProyectsId, up.UserId });

            modelBuilder.Entity<UserProyect>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProyects)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProyect>()
                .HasOne(up => up.Proyects)
                .WithMany(p => p.UserProyects)
                .HasForeignKey(up => up.ProyectsId);
                
            modelBuilder.Entity<ProyectImage>()
                .HasOne(p => p.Proyect);
                
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Proyect) 
                .WithMany()
                .HasForeignKey(r => r.PId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User);
        }
    }
}
