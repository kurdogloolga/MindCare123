using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;
using MindCare.DAL.Entities.Enums;

namespace MindCare.DAL.EntityTypeConfiguration;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(appointment => appointment.Id);

        builder.Property(appointment => appointment.Mode)
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(Mode.Offline);

        builder.Property(appointment => appointment.Reason)
            .HasMaxLength(500);

        builder.HasOne(appointment => appointment.User)
            .WithMany(user => user.Appointments) 
            .HasForeignKey(appointment => appointment.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(appointment => appointment.Specialist)
            .WithMany(specialist => specialist.Appointments) 
            .HasForeignKey(appointment => appointment.SpecialistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
