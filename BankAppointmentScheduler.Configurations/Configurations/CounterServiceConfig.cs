using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class CounterServiceConfig : IEntityTypeConfiguration<CounterService>
    {
        public void Configure(EntityTypeBuilder<CounterService> builder)
        {
            builder.HasKey(x => new {x.CounterId, x.ServiceId})
                .HasName(EntityConstraints.CounterServiceConstraints.KeyConstraints.Name);

            builder.Property(x => x.CounterId)
                .HasColumnName(EntityConstraints.CounterServiceConstraints.KeyConstraints.CounterIdConstraints.Name);

            builder.Property(x => x.ServiceId)
                .HasColumnName(EntityConstraints.CounterServiceConstraints.KeyConstraints.ServiceIdConstraints.Name);

            builder.HasOne(x => x.Counter)
                .WithMany(x => x.CounterServices)
                .HasForeignKey(d => d.CounterId)
                .OnDelete(EntityConstraints.CounterServiceConstraints.CounterForeignKeyConstraints.Behavior)
                .HasConstraintName(EntityConstraints.CounterServiceConstraints.CounterForeignKeyConstraints.ConstraintName);

            builder.HasOne(x => x.Service)
                .WithMany(x => x.CounterServices)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(EntityConstraints.CounterServiceConstraints.ServiceForeignKeyConstraints.Behavior)
                .HasConstraintName(EntityConstraints.CounterServiceConstraints.ServiceForeignKeyConstraints.ConstraintName);
        }
    }
}
