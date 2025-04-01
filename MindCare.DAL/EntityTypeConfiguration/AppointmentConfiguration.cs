using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.StartTime)
                   .IsRequired();

            builder.Property(a => a.EndTime)
                   .IsRequired();

            builder.Property(a => a.Comment)
                   .HasMaxLength(500);

            builder.Property(a => a.Status)
                   .IsRequired();

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Appointments) 
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Specialist)
                   .WithMany(s => s.Appointments) 
                   .HasForeignKey(a => a.SpecialistId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
