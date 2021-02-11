using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.ServiceId)
                .HasName(EntityConstraints.ServiceConstraints.KeyConstraints.Name);

            builder.Property(x => x.ServiceId)
                .HasColumnName(EntityConstraints.ServiceConstraints.KeyConstraints.PropertyName)
                .HasDefaultValueSql(EntityConstraints.ServiceConstraints.KeyConstraints.DefaultValueSql);

            builder.Property(x => x.ServiceName)
                .HasColumnName(EntityConstraints.ServiceConstraints.ServiceNameConstraints.Name)
                .HasMaxLength(EntityConstraints.ServiceConstraints.ServiceNameConstraints.Length)
                .IsRequired(EntityConstraints.ServiceConstraints.ServiceNameConstraints.IsRequired);
        }
    }
}
