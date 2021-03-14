using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService.Requests;
using BankAppointmentScheduler.BankSchedulerService.ResponseModels;
using BankAppointmentScheduler.BankSchedulerService.ViewModels;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.BankSchedulerService
{
    public interface IBankAppointmentSchedulerService
    {
        Task ScheduleAppointment(CreateScheduleModel request, CancellationToken cancellationToken = default);

        Task UpdateAppointment(UpdateScheduleModel request, CancellationToken cancellationToken = default);

        Task ChangeAppointmentStatus(UpdateAppointmentStatus request, CancellationToken cancellationToken = default);

        Task BulkChangeAppointmentStatus(BulkUpdateAppointmentStatus request, CancellationToken cancellationToken = default);

        Task<List<AppointmentStatus>> GetAppointmentStatuses(CancellationToken cancellationToken = default);

        Task<AppointmentListViewModel> GetPaginatedAppointments(GetPaginatedAppointments request, CancellationToken cancellationToken = default);


        Task<AppointmentDetailsModel> GetAppointmentDetails(GetAppointmentDetailsQuery query, CancellationToken cancellationToken = default);

        Task<BranchAppointmentListViewModel> GetBranchAppointments(GetBranchAppointmentsQuery query, CancellationToken cancellationToken = default);
    }
}