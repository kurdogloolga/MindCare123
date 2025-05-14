using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(user => user.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(user => user.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(user => user.Gender)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(user => user.Role)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
