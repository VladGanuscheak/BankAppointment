using System.Collections.Generic;
using BankAppointmentScheduler.BankSchedulerService.DTOs;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class BulkUpdateAppointmentStatus
    {
        public IList<AppointmentKeyDto> Keys { get; set; }
            = new List<AppointmentKeyDto>();

        public AppointmentStatus AppointmentStatus { get; set; }

        public Appointment Map(Appointment entity)
        {
            entity.Status = this.AppointmentStatus.ToString();

            return entity;
        }
    }
}
