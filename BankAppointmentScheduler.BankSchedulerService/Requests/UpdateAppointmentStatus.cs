using System;
using System.ComponentModel.DataAnnotations;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class UpdateAppointmentStatus
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }


        public AppointmentStatus AppointmentStatus { get; set; }

        public Appointment Map([Required] Appointment entity)
        {
            entity.UserId = this.UserId;
            entity.BranchId = this.BranchId;
            entity.ServiceId = this.ServiceId;
            entity.Status = this.AppointmentStatus.ToString();

            return entity;
        }
    }
}
