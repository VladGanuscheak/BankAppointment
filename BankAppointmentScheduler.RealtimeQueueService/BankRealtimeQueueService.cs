using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails.ViewModels;
using Microsoft.EntityFrameworkCore;
using ServiceViewModel = BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails.ViewModels.ServiceViewModel;

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
            var filteredBanks = _context.Banks
                .Where(x => !request.ServiceIds.Any() ||
                            x.Branches.Any(b => b.Counters.Any(c => 
                                c.CounterServices.Any(cs => 
                                    request.ServiceIds.Contains(cs.ServiceId)))));

            var filteredBranches = _context.Branches
                .Where(x => !request.ServiceIds.Any() ||
                            x.Counters.Any(c =>
                                c.CounterServices.Any(cs =>
                                    request.ServiceIds.Contains(cs.ServiceId))));

            var branchCounters = _context.Counters
                .Where(x => !request.ServiceIds.Any() || 
                            x.Branch.Counters.Any(c =>
                                c.CounterServices.Any(cs =>
                                    request.ServiceIds.Contains(cs.ServiceId))));

            var counterServices = _context.CounterServices
                .Where(x => !request.ServiceIds.Any() ||
                            request.ServiceIds.Contains(x.ServiceId));

            var services = _context.Services
                .Where(x => !request.ServiceIds.Any() || 
                            request.ServiceIds.Contains(x.ServiceId));

            var queryResult = (from bank in filteredBanks
                join branch in filteredBranches on bank.Id equals branch.BankId
                join branchCounter in branchCounters on branch.BranchId equals branchCounter.BranchId
                join counterService in counterServices on branchCounter.CounterId equals counterService.CounterId
                join service in services on counterService.ServiceId equals service.ServiceId
                select new BankGeneralDto
                {
                    BankId = bank.Id ?? 0,
                    BankName = bank.Name,
                    Url = bank.Url,
                    BranchId = branch.BranchId,
                    Address = branch.Address,
                    Phone = branch.Phone,
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName
                })
                .Distinct()
                .AsNoTracking();

            return await BankListViewModel.Create(queryResult, cancellationToken);
        }


        public async Task<BranchesListViewModel> GetBankBranches(GetBankBranchesQuery request, CancellationToken cancellationToken)
        {
            var filteredBranches = _context.Branches
                .Where(x => x.BankId == request.BankId);

            var branchCounters = _context.Counters
                .Where(x => x.Branch.BankId == request.BankId);

            var counterServices = _context.CounterServices;

            var services = _context.Services;

            var queryResult = (from branch in filteredBranches
                    join branchCounter in branchCounters on branch.BranchId equals branchCounter.BranchId
                    join counterService in counterServices on branchCounter.CounterId equals counterService.CounterId
                    join service in services on counterService.ServiceId equals service.ServiceId
                    select new BankBranchesDto
                    {
                        BankId = branch.BankId,
                        BranchId = branch.BranchId,
                        Address = branch.Address,
                        Phone = branch.Phone,
                        ServiceId = service.ServiceId,
                        ServiceName = service.ServiceName
                    }).Distinct()
                .AsNoTracking();

            var result = await BranchesListViewModel.Create(queryResult, cancellationToken);

            return result;
        }

        public async Task<BranchDetailsModel> GetBranchDetails(GetBranchDetailsQuery request, CancellationToken cancellationToken)
        {
            var branch = await _context.Branches
                .Where(x => x.BranchId == request.BranchId && x.BankId == request.BankId)
                .Select(BranchDetailsModel.AsQueryableProjection)
                .FirstOrDefaultAsync(cancellationToken);
            if (branch == null) return null;

            var services = await _context.Services
                .Where(x => x.CounterServices.Any(c => c.Counter.BranchId == request.BranchId
                    && c.Counter.Branch.BankId == request.BankId))
                .Select(ServiceViewModel.AsQueryableProjection)
                .ToListAsync(cancellationToken);

            branch.Services = services;

            return branch;
        }

        public async Task<ServiceDetailModel> GetServiceDetails(GetServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var service = await _context.Services
                .Where(x => x.ServiceId == request.ServiceId)
                .Select(ServiceDetailModel.AsQueryableProjection)
                .FirstOrDefaultAsync(cancellationToken);

            return service;
        }

        public async Task<CounterViewModel> GetCounterServices(GetCounterServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _context.Services
                .Where(x => x.CounterServices.Any(cs => cs.ServiceId == request.CounterId))
                .Select(Queries.Services.GetCounterServices.ViewModels.ServiceViewModel.AsQueryableProjection)
                .ToListAsync(cancellationToken);

            return new CounterViewModel
            {
                CounterId = request.CounterId,
                Services = services
            };
        }
    }
}
