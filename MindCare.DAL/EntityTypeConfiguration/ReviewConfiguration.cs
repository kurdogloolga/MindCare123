using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review => review.Id);

            builder.Property(review => review.Rating)
                   .IsRequired();

            builder.Property(review => review.Comment)
                   .HasMaxLength(500);

            builder.HasOne(review => review.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(review => review.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(review => review.Specialist)
                   .WithMany(s => s.Reviews)         
                   .HasForeignKey(review => review.SpecialistId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
