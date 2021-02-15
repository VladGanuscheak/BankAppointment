using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();


        public static Expression<Func<Domain.BankEntities.Entities.Branch, BranchViewModel>> Projection
        {
            get
            {
                return branch => new BranchViewModel()
                {
                    BranchId = branch.BranchId,
                    BankId = branch.BankId,
                    Phone = branch.Phone,
                    Address = branch.Address
                };
            }
        }
    }
}
