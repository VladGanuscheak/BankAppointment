using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BranchManagement.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Administrative.BranchManagement
{
    public interface IBranchManagement
    {
        Task<List<SelectListItem>> GetBranchesSelectList(int? bankId, CancellationToken cancellationToken = default);

        Task CreateBranch(CreateBranchViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBranch(UpdateBranchViewModel request, CancellationToken cancellationToken = default);

        Task ConfigureBranchSchedule(ConfigureBankScheduleViewModel request, CancellationToken cancellationToken = default);

        Task AssignCounterToBranch(AssignCounterToBranchViewModel request, CancellationToken cancellationToken = default);
    }
}
