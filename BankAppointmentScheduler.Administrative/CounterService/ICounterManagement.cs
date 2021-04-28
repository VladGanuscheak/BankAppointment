using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.CounterService.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Administrative.CounterService
{
    public interface ICounterManagement
    {
        Task<List<SelectListItem>> GetCountersSelectList(int? branchId, CancellationToken cancellationToken = default);

        Task CreateCounter(CreateCounterViewModel request, CancellationToken cancellationToken = default);

        Task UpdateCounter(UpdateCounterViewModel request, CancellationToken cancellationToken = default);

        Task AssignOperatorToCounter(AssignOperatorToCounterViewModel request, CancellationToken cancellationToken = default);

        Task AssignServiceToCounter(AssignServiceToCounterViewModel request, CancellationToken cancellationToken = default);
    }
}