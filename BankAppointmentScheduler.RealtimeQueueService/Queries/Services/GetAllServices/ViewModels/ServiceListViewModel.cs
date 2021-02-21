using System.Collections.Generic;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetAllServices.ViewModels
{
    public class ServiceListViewModel
    {
        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();
    }
}
