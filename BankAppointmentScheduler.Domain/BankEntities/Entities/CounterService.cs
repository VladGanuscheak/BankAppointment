namespace BankAppointmentScheduler.Domain.BankEntities.Entities
{
    public class CounterService
    {
        public int CounterId { get; set; }
       
        public int ServiceId { get; set; }



        public Counter Counter { get; set; }

        public Service Service { get; set; }
    }
}
