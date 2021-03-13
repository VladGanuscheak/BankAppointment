using System;

namespace BankAppointmentScheduler.BankSchedulerService.RequestModels
{
    public class GetBranchAppointmentsQuery
    {
        public int BranchId { get; set; }

        public DateTime SearchDate { get; set; }
    }
}
