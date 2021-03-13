using System;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.ServiceManagement
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly IBankAppointmentContext _context;

        public ServiceManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = request.Cast();

            await _context.Services.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateService(RenameServiceViewModel request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Services.FindAsync(request.ServiceId);
            if (entity == null)
                throw new NotFoundException(nameof(Service), request.ServiceId);

            var mappedEntity = request.Map(entity);

            _context.Services.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
