using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BranchManagement.Requests;

namespace BankAppointmentScheduler.Administrative.BranchManagement
{
    public interface IBranchManagement
    {
        Task CreateBranch(CreateBranchViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBranch(UpdateBranchViewModel request, CancellationToken cancellationToken = default);

        Task ConfigureBankSchedule(ConfigureBankScheduleViewModel request, CancellationToken cancellationToken = default);
    }
}
