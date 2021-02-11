using System;

namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Appointment
    {
        public Guid UserId { get; set; }
        
        public int BranchId { get; set; }
        
        public int ServiceId { get; set; }

        public DateTime ArrivalDate { get; set; }
        
        public TimeSpan? ArrivalTime { get; set; }
        
        public string Status { get; set; }
        
        public DateTime? UpdateTimestamp { get; set; }



        public Branch Branch { get; set; }
        
        public Service Service { get; set; }
        
        public User User { get; set; }
    }
}
