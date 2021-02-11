using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => new {x.BranchId, x.WeekDay})
                .HasName(EntityConstraints.ScheduleConstraints.KeyConstraints.Name);

            builder.Property(x => x.BranchId)
                .HasColumnName(EntityConstraints.ScheduleConstraints.KeyConstraints.BranchId.PropertyName);

            builder.Property(x => x.WeekDay)
                .HasColumnName(EntityConstraints.ScheduleConstraints.KeyConstraints.WeekDay.PropertyName)
                .HasMaxLength(EntityConstraints.ScheduleConstraints.KeyConstraints.WeekDay.Length);

            builder.Property(x => x.OpeningTime)
                .HasColumnName(EntityConstraints.ScheduleConstraints.OpeningTime.Name)
                .HasColumnType(EntityConstraints.ScheduleConstraints.OpeningTime.ColumnTypeName);

            builder.Property(x => x.ClosingTime)
                .HasColumnName(EntityConstraints.ScheduleConstraints.ClosingTime.Name)
                .HasColumnType(EntityConstraints.ScheduleConstraints.ClosingTime.ColumnTypeName);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Schedules)
                .HasPrincipalKey(x => x.BranchId)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(EntityConstraints.ScheduleConstraints.BranchForeignKeyConstraint.Behavior)
                .HasConstraintName(EntityConstraints.ScheduleConstraints.BranchForeignKeyConstraint.Name);
        }
    }
}
