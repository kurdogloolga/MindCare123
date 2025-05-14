using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasKey(specialist => specialist.Id);

            builder.Property(specialist => specialist.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(specialist => specialist.Description)
                   .HasMaxLength(1000);

            builder.Property(specialist => specialist.Specialization)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(specialist => specialist.PricePerSession)
                   .HasColumnType("decimal(18,2)");

            builder.Property(specialist => specialist.Rating)
                   .HasPrecision(3, 2);
        }
    }
}
