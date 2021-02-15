using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Services.ViewModels
{
    public class ServiceListViewModel
    {
        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();
    }
}
