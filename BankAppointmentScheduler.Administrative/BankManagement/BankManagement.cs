using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BankManagement.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BankManagement
{
    public class BankManagement : IBankManagement
    {
        private readonly IBankAppointmentContext _context;

        public BankManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task CreateBank(CreateBankViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = request.Cast();

            await _context.Banks.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBank(UpdateBankViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Banks.FindAsync(request.BankId);
            if (entity == null)
                throw new NotFoundException(nameof(Bank), request.BankId);

            var mappedEntity = request.Map(entity);

            _context.Banks.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RenameBank(RenameBankViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Banks.FindAsync(request.BankId);
            if (entity == null)
                throw new NotFoundException(nameof(Bank), request.BankId);

            var mappedEntity = request.Map(entity);

            _context.Banks.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBankUrl(UpdateBankUrlViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Banks.FindAsync(request.BankId);
            if (entity == null)
                throw new NotFoundException(nameof(Bank), request.BankId);

            var mappedEntity = request.Map(entity);

            _context.Banks.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
