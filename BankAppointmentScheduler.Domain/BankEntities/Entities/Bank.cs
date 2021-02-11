using System.Collections.Generic;


namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Bank
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        
        public string Url { get; set; }


        public ICollection<Branch> Branches { get; set; }
    }
}
