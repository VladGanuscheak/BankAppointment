using System;
using System.Collections.Generic;

namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Counter
    {
        public int CounterId { get; set; }

        public int? BranchId { get; set; }

        public Guid? OperatorId { get; set; }

        public int CounterNumber { get; set; }

        
        public User Operator { get; set; }

        public Branch Branch { get; set; }
        
        public ICollection<CounterService> CounterServices { get; set; }
    }
}
