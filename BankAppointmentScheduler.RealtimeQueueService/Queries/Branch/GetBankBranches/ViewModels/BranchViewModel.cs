using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
            = new List<ServiceViewModel>();


        private static Expression<Func<KeyValuePair<int, List<BranchDto>>, BranchViewModel>> Projection
        {
            get
            {
                return branch => new BranchViewModel
                {
                    BranchId = branch.Key,
                    BankId = branch.Value[0].BankId,
                    Address = branch.Value[0].Address,
                    Phone = branch.Value[0].Phone,
                    Services = branch.Value.GroupBy(x => x.ServiceId, ServiceDto.Create)
                        .ToDictionary(x => x.Key, x => x.FirstOrDefault())
                        .Select(ServiceViewModel.Create).ToList()
                };
            }
        }

        public static BranchViewModel Create(KeyValuePair<int, List<BranchDto>> branch)
        {
            return Projection.Compile().Invoke(branch);
        }
    }
}
