using System.Collections.Generic;

#nullable disable

namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        
        public int BankId { get; set; }
        
        public string Phone { get; set; }
        
        public string Address { get; set; }



        public Bank Bank { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        
        public ICollection<Counter> Counters { get; set; }
        
        public ICollection<Schedule> Schedules { get; set; }
    }
}
