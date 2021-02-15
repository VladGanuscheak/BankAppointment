using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class BankListViewModel
    {
        public IList<BankViewModel> Banks { get; set; }
            = new List<BankViewModel>();
    }
}
