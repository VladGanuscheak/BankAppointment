using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class CounterConfig : IEntityTypeConfiguration<Counter>
    {
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            builder.HasKey(x => x.CounterId)
                .HasName(EntityConstraints.CounterConstraints.KeyConstraints.Name);

            builder.Property(x => x.CounterId)
                .HasColumnName(EntityConstraints.CounterConstraints.KeyConstraints.PropertyName)
                .HasDefaultValueSql(EntityConstraints.CounterConstraints.KeyConstraints.DefaultValueSql);

            builder.Property(x => x.BranchId)
                .HasColumnName(EntityConstraints.CounterConstraints.BranchIdConstraints.Name);

            builder.Property(x => x.OperatorId)
                .HasColumnName(EntityConstraints.CounterConstraints.OperatorIdConstraints.Name);

            builder.Property(x => x.CounterNumber)
                .HasColumnName(EntityConstraints.CounterConstraints.CounterNumberConstraints.Name);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Counters)
                .HasPrincipalKey(x => x.BranchId)
                .HasForeignKey(x => x.BranchId)
                .HasConstraintName(EntityConstraints.CounterConstraints.BranchForeignKeyConstraint.ConstraintName);

            builder.HasOne(x => x.Operator)
                .WithMany(x => x.Counters)
                .HasForeignKey(x => x.OperatorId)
                .HasConstraintName(EntityConstraints.CounterConstraints.OperatorForeignKeyConstraint.ConstraintName);
        }
    }
}
