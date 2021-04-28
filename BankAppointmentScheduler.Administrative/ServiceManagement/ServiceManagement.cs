using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.Administrative.ServiceManagement
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly IBankAppointmentContext _context;

        public ServiceManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetServicesSelectList(int? counterId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Services
                .Where(x => counterId == null || x.CounterServices
                    .Any(cs => cs.CounterId == counterId))
                .Select(x => new SelectListItem
                {
                    Text = x.ServiceName,
                    Value = x.ServiceId.ToString()
                }).ToListAsync(cancellationToken);

            return result;
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
