using System;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs
{
    public class BankDto
    {
        public string BankName { get; set; }

        public string Url { get; set; }


        public int BranchId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        private static Expression<Func<BankGeneralDto, BankDto>> Projection
        {
            get
            {
                return bank => new BankDto
                {
                    BankName = bank.BankName,
                    Url = bank.Url,
                    Address = bank.Address,
                    BranchId = bank.BranchId,
                    Phone = bank.Phone,
                    ServiceId = bank.ServiceId,
                    ServiceName = bank.ServiceName
                };
            }
        }

        public static BankDto Create(BankGeneralDto bank)
        {
            return Projection.Compile().Invoke(bank);
        }
    }
}
