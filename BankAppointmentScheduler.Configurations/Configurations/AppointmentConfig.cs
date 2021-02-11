using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAppointmentScheduler.Configurations.Configurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => new {x.UserId, x.BranchId, x.ServiceId})
                .HasName(EntityConstraints.AppointmentConstraints.KeyConstraints.Name);

            builder.Property(x => x.UserId)
                .HasColumnName(EntityConstraints.AppointmentConstraints.KeyConstraints.UserIdConstraints.PropertyName);

            builder.Property(x => x.BranchId)
                .HasColumnName(EntityConstraints.AppointmentConstraints.KeyConstraints.BranchIdConstraints.PropertyName);

            builder.Property(x => x.ServiceId)
                .HasColumnName(EntityConstraints.AppointmentConstraints.KeyConstraints.ServiceIdConstraints.PropertyName);

            builder.Property(x => x.ArrivalDate)
                .HasColumnName(EntityConstraints.AppointmentConstraints.ArrivalDateConstraints.Name)
                .HasColumnType(EntityConstraints.AppointmentConstraints.ArrivalDateConstraints.ColumnTypeName);

            builder.Property(x => x.ArrivalTime)
                .HasColumnName(EntityConstraints.AppointmentConstraints.ArrivalTimeConstraints.Name)
                .HasColumnType(EntityConstraints.AppointmentConstraints.ArrivalTimeConstraints.ColumnTypeName);

            builder.Property(x => x.Status)
                .HasColumnName(EntityConstraints.AppointmentConstraints.StatusConstraints.Name)
                .HasMaxLength(EntityConstraints.AppointmentConstraints.StatusConstraints.Length);

            builder.Property(x => x.UpdateTimestamp)
                .HasColumnName(EntityConstraints.AppointmentConstraints.UpdateTimeStampConstraints.Name);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Appointments)
                .HasPrincipalKey(p => p.BranchId)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(EntityConstraints.AppointmentConstraints.BranchForeignKeyConstraint.Behavior)
                .HasConstraintName(EntityConstraints.AppointmentConstraints.BranchForeignKeyConstraint.ConstraintName);

            builder.HasOne(x => x.Service)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(EntityConstraints.AppointmentConstraints.ServiceForeignKeyConstraint.Behavior)
                .HasConstraintName(EntityConstraints.AppointmentConstraints.ServiceForeignKeyConstraint.ConstraintName);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(EntityConstraints.AppointmentConstraints.UserForeignKeyConstraint.Behavior)
                .HasConstraintName(EntityConstraints.AppointmentConstraints.UserForeignKeyConstraint.ConstraintName);
        }
    }
}
