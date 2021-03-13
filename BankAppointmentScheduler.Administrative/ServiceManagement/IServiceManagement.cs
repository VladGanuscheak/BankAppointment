using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;

namespace BankAppointmentScheduler.Administrative.ServiceManagement
{
    public interface IServiceManagement
    {
        Task CreateService(CreateServiceViewModel request, CancellationToken cancellationToken = default);

        Task UpdateService(RenameServiceViewModel request, CancellationToken cancellationToken = default);
    }
}
