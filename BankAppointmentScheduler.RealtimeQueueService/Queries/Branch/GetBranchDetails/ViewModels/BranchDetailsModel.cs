using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails.ViewModels
{
    public class BranchDetailsModel
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();


        public static Expression<Func<Domain.BankEntities.Entities.Branch, BranchDetailsModel>> AsQueryableProjection
        {
            get
            {
                return branch => new BranchDetailsModel
                {
                    BankId = branch.BankId,
                    BranchId = branch.BranchId,
                    Address = branch.Address,
                    Phone = branch.Phone
                };
            }
        }
    }
}
