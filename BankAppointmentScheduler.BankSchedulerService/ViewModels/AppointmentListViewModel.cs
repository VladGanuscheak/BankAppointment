using System.Collections.Generic;

namespace BankAppointmentScheduler.BankSchedulerService.ViewModels
{
    public class AppointmentListViewModel
    {
        public int TotalNumberOfElements { get; set; }

        public IList<AppointmentViewModel> Appointments { get; set; }
    }
}
