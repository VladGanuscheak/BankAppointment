using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.ViewModels
{
    public class BranchesListViewModel
    {
        public IList<BranchViewModel> Branches { get; set; }
            = new List<BranchViewModel>();


        public static async Task<BranchesListViewModel> Create(IQueryable<BankBranchesDto> queryResult, CancellationToken cancellationToken)
        {
            var result = await queryResult.ToListAsync(cancellationToken);

            return await Task.Run(() =>
            {
                var branchGroups = result.GroupBy(x => x.BranchId, BranchDto.Create)
                    .ToDictionary(x => x.Key, x => x.ToList());

                return new BranchesListViewModel
                {
                    Branches = branchGroups.Select(BranchViewModel.Create).ToList()
                };
            }, cancellationToken);
        }
    }
}
