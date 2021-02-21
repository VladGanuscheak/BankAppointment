using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails.ViewModels;

namespace BankAppointmentScheduler.RealtimeQueueService
{
    public interface IBankRealtimeQueueService
    {
        Task<BankListViewModel> GetAllBanks(GetAllBanksQuery request, CancellationToken cancellationToken);

        Task<BranchesListViewModel> GetBankBranches(GetBankBranchesQuery request, CancellationToken cancellationToken);

        Task<BranchDetailsModel> GetBranchDetails(GetBranchDetailsQuery request, CancellationToken cancellationToken);

        Task<ServiceDetailModel> GetServiceDetails(GetServiceDetailsQuery request, CancellationToken cancellationToken);

        Task<CounterViewModel> GetCounterServices(GetCounterServicesQuery request, CancellationToken cancellationToken);
    }
}