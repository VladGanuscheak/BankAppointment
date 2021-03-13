using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BranchManagement.Requests
{
    public class CreateBranchViewModel
    {
        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Branch Cast()
        {
            return new Branch
            {
                BankId = this.BankId,
                Phone = this.Phone,
                Address = this.Address
            };
        }
    }
}
