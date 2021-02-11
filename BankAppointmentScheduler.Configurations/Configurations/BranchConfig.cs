using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => new {x.BranchId, x.BankId})
                .HasName(EntityConstraints.BranchConstraints.KeyConstraints.Name);

            builder.Property(x => x.BranchId)
                .HasColumnName(EntityConstraints.BranchConstraints.KeyConstraints.PropertyName)
                .HasDefaultValueSql(EntityConstraints.BranchConstraints.KeyConstraints.DefaultValueSql);

            builder.HasIndex(x => x.BranchId)
                .HasDatabaseName(EntityConstraints.BranchConstraints.KeyConstraints.IndexName)
                .IsUnique();

            builder.Property(x => x.BankId)
                .HasColumnName(EntityConstraints.BranchConstraints.BankIdConstraints.PropertyName);

            builder.Property(x => x.Phone)
                .HasMaxLength(EntityConstraints.BranchConstraints.PhoneConstraints.Length)
                .IsRequired(EntityConstraints.BranchConstraints.PhoneConstraints.IsRequired)
                .HasColumnName(EntityConstraints.BranchConstraints.PhoneConstraints.Name);

            builder.Property(x => x.Address)
                .HasMaxLength(EntityConstraints.BranchConstraints.AddressConstraints.Length)
                .IsRequired(EntityConstraints.BranchConstraints.AddressConstraints.IsRequired)
                .HasColumnName(EntityConstraints.BranchConstraints.AddressConstraints.Name);

            builder.HasOne(x => x.Bank)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.BankId)
                .HasForeignKey(x => x.BankId)
                .OnDelete(EntityConstraints.BranchConstraints.BankForeignKeyConstraint.Behavior)
                .HasConstraintName(EntityConstraints.BranchConstraints.BankForeignKeyConstraint.Name);
        }
    }
}
