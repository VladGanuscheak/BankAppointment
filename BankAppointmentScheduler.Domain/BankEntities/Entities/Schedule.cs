using System;


namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class Schedule
    {
        public int BranchId { get; set; }
        
        public string WeekDay { get; set; }
        
        public TimeSpan OpeningTime { get; set; }
        
        public TimeSpan ClosingTime { get; set; }



        public Branch Branch { get; set; }
    }
}
