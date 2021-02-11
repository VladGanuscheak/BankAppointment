using System;
using System.Collections.Generic;


namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        

        public ICollection<Appointment> Appointments { get; set; }
        
        public ICollection<Counter> Counters { get; set; }
    }
}
