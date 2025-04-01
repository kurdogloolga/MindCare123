using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(s => s.Description)
                   .HasMaxLength(1000);

            builder.Property(s => s.Specialization)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(s => s.PricePerSession)
                   .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Rating)
                   .HasPrecision(3, 2);
        }
    }
}
