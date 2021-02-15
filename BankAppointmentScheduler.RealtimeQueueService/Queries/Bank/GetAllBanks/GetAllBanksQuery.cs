using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks
{
    public class GetAllBanksQuery
    {
        public List<int> ServiceIds { get; set; }
            = new List<int>();
    }
}
