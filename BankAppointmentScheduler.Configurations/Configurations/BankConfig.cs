using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class BankConfig : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName(EntityConstraints.BankConstraints.KeyConstraints.Name);

            builder.Property(x => x.Id)
                .HasDefaultValueSql(EntityConstraints.BankConstraints.KeyConstraints.DefaultValueSql)
                .HasColumnName(EntityConstraints.BankConstraints.KeyConstraints.PropertyName);

            builder.Property(x => x.Name)
                .HasMaxLength(EntityConstraints.BankConstraints.NameConstraints.Length)
                .HasColumnName(EntityConstraints.BankConstraints.NameConstraints.Name)
                .IsRequired(EntityConstraints.BankConstraints.NameConstraints.IsRequired);

            builder.Property(x => x.Url)
                .HasMaxLength(EntityConstraints.BankConstraints.UrlConstraints.Length)
                .HasColumnName(EntityConstraints.BankConstraints.UrlConstraints.Name)
                .IsRequired(EntityConstraints.BankConstraints.UrlConstraints.IsRequired);
        }
    }
}
