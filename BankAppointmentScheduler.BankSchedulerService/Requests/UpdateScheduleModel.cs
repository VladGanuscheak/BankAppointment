using System;
using System.ComponentModel.DataAnnotations;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class UpdateScheduleModel
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }


        public AppointmentStatus AppointmentStatus { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }


        public Appointment Map([Required] Appointment entity)
        {
            entity.UserId = this.UserId;
            entity.BranchId = this.BranchId;
            entity.ServiceId = this.ServiceId;
            entity.Status = this.AppointmentStatus.ToString();
            entity.ArrivalDate = this.ArrivalDate;
            entity.ArrivalTime = this.ArrivalTime;
            entity.UpdateTimestamp = DateTime.UtcNow;

            return entity;
        }
    }
}
