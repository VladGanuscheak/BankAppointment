namespace BankAppointmentScheduler.Administrative.CounterService.Requests
{
    public class AssignServiceToCounterViewModel
    {
        public int CounterId { get; set; }

        public int ServiceId { get; set; }

        public Domain.BankEntities.Entities.CounterService Cast()
        {
            return new Domain.BankEntities.Entities.CounterService
            {
                CounterId = this.CounterId,
                ServiceId = this.ServiceId
            };
        }
    }
}
