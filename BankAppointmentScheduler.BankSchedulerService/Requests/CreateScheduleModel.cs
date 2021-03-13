using System;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class CreateScheduleModel
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }


        public AppointmentStatus AppointmentStatus { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }


        public Appointment Cast()
        {
            return new Appointment
            {
                UserId = this.UserId,
                BranchId = this.BranchId,
                ServiceId = this.ServiceId,
                Status = this.AppointmentStatus.ToString(),
                ArrivalDate = this.ArrivalDate,
                ArrivalTime = this.ArrivalTime,
                UpdateTimestamp = null
            };
        }
    }
}
