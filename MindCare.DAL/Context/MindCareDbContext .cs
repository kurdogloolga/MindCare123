using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;
using MindCare.DAL.EntityTypeConfiguration;

namespace MindCare.DAL.Context
{
    public class MindCareDbContext : DbContext
    {
        public MindCareDbContext(DbContextOptions<MindCareDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialistConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
