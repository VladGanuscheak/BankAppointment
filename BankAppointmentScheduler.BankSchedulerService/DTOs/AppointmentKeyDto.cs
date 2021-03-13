using System;

namespace BankAppointmentScheduler.BankSchedulerService.DTOs
{
    public class AppointmentKeyDto
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }
    }
}
