using System;

namespace BankAppointmentScheduler.BankSchedulerService.RequestModels
{
    public class GetAppointmentDetailsQuery
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }
    }
}
