using System;

namespace BankAppointmentScheduler.BankSchedulerService.RequestModels
{
    public class UpdateAppointmentCommand
    {
        public int UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public DateTime? UpdateTimestamp { get; set; }

        public string Status { get; set; }
    }
}
