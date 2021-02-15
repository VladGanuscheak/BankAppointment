using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetBankDetails.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.RealtimeQueueService
{
    public class BankRealtimeQueueService : IBankRealtimeQueueService
    {
        private readonly IBankAppointmentContext _context;

        public BankRealtimeQueueService(IBankAppointmentContext context)
        {
            _context = context;
        }


        public async Task<BankListViewModel> GetAllBanks(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var banks = await _context.Banks
                .Where(x => x.Branches.Any(b => b.Counters.Any(c => 
                    c.CounterServices.Any(cs => 
                        request.ServiceIds.Contains(cs.ServiceId)))))
                .Select(BankViewModel.Projection)
                .ToListAsync(cancellationToken);

            return new BankListViewModel();
        }

        public Task<BankListViewModel> GetAllBanks(GetAllBanksQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<BankDetailsModel> GetBankDetails(GetBankDetailsQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBankBranchesQuery> GetBankBranches(GetBankBranchesQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<BankDetailsModel> GetBranchDetails(GetBranchDetailsQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<GetServiceDetailsQuery> GetServiceDetails(GetServiceDetailsQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<CounterViewModel> GetCounterServices(GetCounterServicesQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
