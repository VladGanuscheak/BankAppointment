using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetBankDetails.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();
    }
}
