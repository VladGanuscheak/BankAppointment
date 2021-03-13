using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.CounterService.Requests;

namespace BankAppointmentScheduler.Administrative.CounterService
{
    public interface ICounterManagement
    {
        Task CreateCounter(CreateCounterViewModel request, CancellationToken cancellationToken = default);

        Task UpdateCounter(UpdateCounterViewModel request, CancellationToken cancellationToken = default);

        Task AssignOperatorToCounter(AssignOperatorToCounterViewModel request, CancellationToken cancellationToken = default);

        Task AssignServiceToCounter(AssignServiceToCounterViewModel request, CancellationToken cancellationToken = default);
    }
}