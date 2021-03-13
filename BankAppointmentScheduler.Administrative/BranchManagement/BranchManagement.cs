using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BranchManagement.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BranchManagement
{
    public class BranchManagement : IBranchManagement
    {
        private readonly IBankAppointmentContext _context;

        public BranchManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task CreateBranch(CreateBranchViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = request.Cast();

            await _context.Branches.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBranch(UpdateBranchViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Branches.FindAsync(request.BranchId, request.BankId);
            if (entity == null)
                throw new NotFoundException(nameof(Branch), new {request.BranchId, request.BankId});

            var mappedEntity = request.Map(entity);

            _context.Branches.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ConfigureBranchSchedule(ConfigureBankScheduleViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = request.OldWeekDay.HasValue
                ? await _context.Schedules.FindAsync(request.BranchId, request.OldWeekDay)
                : null;

            var mappedEntity = entity == null 
                ? request.Cast() 
                : request.Map(entity);

            await _context.Schedules.AddAsync(mappedEntity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AssignCounterToBranch(AssignCounterToBranchViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Counters.FindAsync(request.CounterId);
            if (entity == null)
                throw new NotFoundException(nameof(Counter), request.CounterId);

            var mappedEntity = request.Map(entity);

            _context.Counters.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
