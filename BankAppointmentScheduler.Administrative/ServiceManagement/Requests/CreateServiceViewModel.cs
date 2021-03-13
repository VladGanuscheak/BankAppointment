using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.ServiceManagement.Requests
{
    public class CreateServiceViewModel
    {
        public string ServiceName { get; set; }

        public Service Cast()
        {
            return new Service
            {
                ServiceName = this.ServiceName
            };
        }
    }
}
