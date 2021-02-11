using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId)
                .HasName(EntityConstraints.UserConstraints.KeyConstraints.Name);

            builder.Property(x => x.UserId)
                .HasColumnName(EntityConstraints.UserConstraints.KeyConstraints.PropertyName)
                .HasDefaultValueSql(EntityConstraints.UserConstraints.KeyConstraints.DefaultValueSql);

            builder.Property(x => x.Email)
                .HasColumnName(EntityConstraints.UserConstraints.EmailConstraints.Name)
                .HasMaxLength(EntityConstraints.UserConstraints.EmailConstraints.Length)
                .IsRequired(EntityConstraints.UserConstraints.EmailConstraints.IsRequired);

            builder.Property(x => x.FirstName)
                .HasColumnName(EntityConstraints.UserConstraints.FirstNameConstraints.Name)
                .HasMaxLength(EntityConstraints.UserConstraints.FirstNameConstraints.Length)
                .IsRequired(EntityConstraints.UserConstraints.FirstNameConstraints.IsRequired);

            builder.Property(x => x.LastName)
                .HasColumnName(EntityConstraints.UserConstraints.LastNameConstraints.Name)
                .HasMaxLength(EntityConstraints.UserConstraints.LastNameConstraints.Length)
                .IsRequired(EntityConstraints.UserConstraints.LastNameConstraints.IsRequired);
        }
    }
}
