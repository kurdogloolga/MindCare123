using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration;
public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.HasKey(availability => availability.Id);

        builder.HasOne(availability => availability.Specialist)
            .WithMany(specialist => specialist.Availabilities)
            .HasForeignKey(availability => availability.SpecialistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
