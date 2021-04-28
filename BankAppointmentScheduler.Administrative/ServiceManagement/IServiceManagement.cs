using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Administrative.ServiceManagement
{
    public interface IServiceManagement
    {
        Task<List<SelectListItem>> GetServicesSelectList(int? counterId, CancellationToken cancellationToken = default);

        Task CreateService(CreateServiceViewModel request, CancellationToken cancellationToken = default);

        Task UpdateService(RenameServiceViewModel request, CancellationToken cancellationToken = default);
    }
}
