namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs
{
    public class BankBranchesDto
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }
    }
}
