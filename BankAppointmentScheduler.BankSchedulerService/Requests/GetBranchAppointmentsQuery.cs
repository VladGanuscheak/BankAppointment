using System;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class GetBranchAppointmentsQuery
    {
        public int BranchId { get; set; }

        public DateTime SearchDate { get; set; }
    }
}
