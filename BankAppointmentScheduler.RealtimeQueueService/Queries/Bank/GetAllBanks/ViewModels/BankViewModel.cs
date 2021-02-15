using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class BankViewModel
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public string Url { get; set; }

        public IList<BranchViewModel> Branches { get; set; }
            = new List<BranchViewModel>();


        public static Expression<Func<Domain.BankEntities.Entities.Bank, BankViewModel>> Projection
        {
            get
            {
                return bank => new BankViewModel
                {
                    BankId = bank.Id ?? -1,
                    BankName = bank.Name,
                    Url = bank.Url,
                    Branches = bank.Branches.AsQueryable()
                        .Select(BranchViewModel.Projection).ToList()
                };
            }
        }
    }
}
