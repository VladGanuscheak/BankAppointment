using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.CounterService.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.CounterService
{
    public class CounterManagement : ICounterManagement
    {
        private readonly IBankAppointmentContext _context;

        public CounterManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task CreateCounter(CreateCounterViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = request.Cast();

            await _context.Counters.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCounter(UpdateCounterViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Counters.FindAsync(request.CounterId);
            if (entity == null)
                throw new NotFoundException(nameof(Counter), request.CounterId);

            var mappedEntity = request.Map(entity);

            _context.Counters.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AssignOperatorToCounter(AssignOperatorToCounterViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Counters.FindAsync(request.CounterId);
            if (entity == null)
                throw new NotFoundException(nameof(Counter), request.CounterId);

            var mappedEntity = request.Map(entity);

            _context.Counters.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AssignServiceToCounter(AssignServiceToCounterViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.CounterServices.FindAsync(request.CounterId, request.ServiceId);
            if (entity != null) return;

            var newEntity = request.Cast();

            await _context.CounterServices.AddAsync(newEntity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
