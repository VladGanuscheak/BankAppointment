using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService.RequestModels;
using BankAppointmentScheduler.BankSchedulerService.ResponseModels;
using BankAppointmentScheduler.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.BankSchedulerService
{
    public class BankAppointmentScheduler : IBankAppointmentScheduler
    {
        private readonly IBankAppointmentContext _context;

        public BankAppointmentScheduler(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task CreateAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken = default)
        {
            var appointment = command.Cast();

            await _context.Appointments.AddAsync(appointment, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAppointment(UpdateAppointmentCommand command, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Appointments.FindAsync(command.UserId, command.BranchId, command.ServiceId);
            entity.ArrivalDate = command.ArrivalDate;
            entity.ArrivalTime = command.ArrivalTime;
            entity.UpdateTimestamp = command.UpdateTimestamp;
            entity.Status = command.Status;

            _context.Appointments.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<AppointmentDetailsModel> GetAppointmentDetails(GetAppointmentDetailsQuery query, CancellationToken cancellationToken = default)
        {
            var appointment = await _context.Appointments
                .Where(x => x.UserId == query.UserId &&
                            x.BranchId == query.BranchId &&
                            x.ServiceId == query.ServiceId)
                .Select(AppointmentDetailsModel.AsQueryableProjection)
                .FirstOrDefaultAsync(cancellationToken);

            return appointment;
        }

        public async Task<BranchAppointmentListViewModel> GetBranchAppointments(GetBranchAppointmentsQuery query, CancellationToken cancellationToken = default)
        {
            var branch = await _context.Branches
                .Where(x => x.BranchId == query.BranchId)
                .Select(BranchAppointmentListViewModel.AsQueryableProjection)
                .FirstOrDefaultAsync(cancellationToken);

            var appointments = await _context.Appointments
                .Where(x => x.BranchId == query.BranchId && x.ArrivalDate.Date == query.SearchDate)
                .Select(BranchAppointmentViewModel.AsQueryableProjection)
                .ToListAsync(cancellationToken);

            branch.Appointments = appointments;

            return branch;
        }
    }
}
