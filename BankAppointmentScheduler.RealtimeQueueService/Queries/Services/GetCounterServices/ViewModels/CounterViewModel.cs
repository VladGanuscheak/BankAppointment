using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels
{
    public class CounterViewModel
    {
        public int CounterId { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();
    }
}
