using System;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs
{
    public class BranchDto
    {
        public string Phone { get; set; }

        public string Address { get; set; }


        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        private static Expression<Func<BankDto, BranchDto>> Projection
        {
            get
            {
                return branch => new BranchDto
                {
                    Phone = branch.Phone,
                    Address = branch.Address,
                    ServiceId = branch.ServiceId,
                    ServiceName = branch.ServiceName
                };
            }
        }

        public static BranchDto Create(BankDto bank)
        {
            return Projection.Compile().Invoke(bank);
        }
    }
}
