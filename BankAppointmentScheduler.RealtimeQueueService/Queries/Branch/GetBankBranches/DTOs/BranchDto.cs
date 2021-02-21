using System;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs
{
    public class BranchDto
    {
        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        private static Expression<Func<BankBranchesDto, BranchDto>> Projection
        {
            get
            {
                return bankBranch => new BranchDto
                {
                    BankId = bankBranch.BankId,
                    Address = bankBranch.Address,
                    Phone = bankBranch.Phone,
                    ServiceId = bankBranch.ServiceId,
                    ServiceName = bankBranch.ServiceName
                };
            }
        }

        public static BranchDto Create(BankBranchesDto bankBranch)
        {
            return Projection.Compile().Invoke(bankBranch);
        }
    }
}
