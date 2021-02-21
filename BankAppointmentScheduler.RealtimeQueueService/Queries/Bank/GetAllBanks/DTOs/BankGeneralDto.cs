namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs
{
    public class BankGeneralDto
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public string Url { get; set; }


        public int BranchId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public int ServiceId { get; set; }

        public string ServiceName { get; set; }
    }
}
