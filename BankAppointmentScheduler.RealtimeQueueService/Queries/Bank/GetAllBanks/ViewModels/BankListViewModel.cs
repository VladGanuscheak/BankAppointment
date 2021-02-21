using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class BankListViewModel
    {
        public IList<BankViewModel> Banks { get; set; }
            = new List<BankViewModel>();

        public static async Task<BankListViewModel> Create(IQueryable<BankGeneralDto> queryResult, CancellationToken cancellationToken)
        {
            var result = await queryResult.ToListAsync(cancellationToken);

            return await Task.Run(() =>
            {
                var bankGroups = result.GroupBy(x => x.BankId, BankDto.Create)
                    .ToDictionary(x => x.Key, x => x.ToList());

                return new BankListViewModel()
                {
                    Banks = bankGroups.Select(BankViewModel.Create).ToList()
                };
            }, cancellationToken);
        }
    }
}
