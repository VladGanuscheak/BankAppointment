using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetBankDetails.ViewModels
{
    public class BankDetailsModel
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public string Url { get; set; }

        public IList<BranchViewModel> Branches { get; set; }
            = new List<BranchViewModel>();
    }
}
