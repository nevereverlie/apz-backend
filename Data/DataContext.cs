using Apz_backend.Models;
using Apz_backend.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Apz_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.HospitalAnimals)
                .WithOne(h => h.Hospital)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Users)
                .WithOne(h => h.Hospital)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Schedules)
                .WithOne(a => a.Animal)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medication>()
                .HasMany(m => m.Schedules)
                .WithOne(m => m.Medication)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.User)
                .WithMany(m => m.Medications)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schedule>()
                .HasKey(h => new { h.AnimalId, h.MedicationId });

            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.Medications)
                .WithOne(m => m.Medicine)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Medications)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Hospital)
                .WithMany(u => u.Users)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}