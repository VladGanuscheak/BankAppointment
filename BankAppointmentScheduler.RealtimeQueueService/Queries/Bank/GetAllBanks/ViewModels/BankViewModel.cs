using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class BankViewModel
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public string Url { get; set; }

        public IList<BranchViewModel> Branches { get; set; }
            = new List<BranchViewModel>();


        private static Expression<Func<KeyValuePair<int, List<BankDto>>, BankViewModel>> Projection
        {
            get
            {
                return bank => new BankViewModel
                {
                    BankId = bank.Key,
                    BankName = bank.Value[0].BankName,
                    Url = bank.Value[0].Url,
                    Branches = bank.Value.GroupBy(x => x.BranchId, BranchDto.Create)
                        .ToDictionary(x => x.Key, x => x.ToList())
                        .Select(BranchViewModel.Create).ToList()
                };
            }
        }

        public static BankViewModel Create(KeyValuePair<int, List<BankDto>> bank)
        {
            return Projection.Compile().Invoke(bank);
        }
    }
}
