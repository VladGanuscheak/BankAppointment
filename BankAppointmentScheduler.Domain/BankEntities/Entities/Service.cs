using System.Collections.Generic;


namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        
        public string ServiceName { get; set; }

        

        public ICollection<Appointment> Appointments { get; set; }
        
        public ICollection<CounterService> CounterServices { get; set; }
    }
}
