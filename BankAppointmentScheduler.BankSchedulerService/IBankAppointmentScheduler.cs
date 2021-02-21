using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService.RequestModels;
using BankAppointmentScheduler.BankSchedulerService.ResponseModels;

namespace BankAppointmentScheduler.BankSchedulerService
{
    public interface IBankAppointmentScheduler
    {
        Task CreateAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken = default);

        Task UpdateAppointment(UpdateAppointmentCommand command, CancellationToken cancellationToken = default);

        Task<AppointmentDetailsModel> GetAppointmentDetails(GetAppointmentDetailsQuery query, CancellationToken cancellationToken = default);

        Task<BranchAppointmentListViewModel> GetBranchAppointments(GetBranchAppointmentsQuery query, CancellationToken cancellationToken = default);
    }
}