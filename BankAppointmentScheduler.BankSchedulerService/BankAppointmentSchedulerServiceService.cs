using BankAppointmentScheduler.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService.Requests;
using BankAppointmentScheduler.BankSchedulerService.ViewModels;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Common.Extensions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.BankSchedulerService
{
    public class BankAppointmentSchedulerServiceService : IBankAppointmentSchedulerService
    {
        private readonly IBankAppointmentContext _context;

        public BankAppointmentSchedulerServiceService(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task ScheduleAppointment(CreateScheduleModel model, CancellationToken cancellationToken)
        {
            var entity = model.Cast();
            await _context.Appointments.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAppointment(UpdateScheduleModel model, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Appointments.FindAsync(model.UserId, model.BranchId, model.ServiceId);
            if (entity == null)
                throw new NotFoundException(nameof(Appointment), new { model.UserId, model.BranchId, model.ServiceId });

            var mappedEntity = model.Map(entity);

            _context.Appointments.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeAppointmentStatus(UpdateAppointmentStatus model, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Appointments.FindAsync(model.UserId, model.BranchId, model.ServiceId);
            if (entity == null)
                throw new NotFoundException(nameof(Appointment), new { model.UserId, model.BranchId, model.ServiceId });

            var mappedEntity = model.Map(entity);

            _context.Appointments.Update(mappedEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BulkChangeAppointmentStatus(BulkUpdateAppointmentStatus request, CancellationToken cancellationToken = default)
        {
            if (!(request.Keys?.Any() ?? false))
                throw new NotFoundException(nameof(Appointment), request.Keys);

            var usersToSearch = request.Keys.Select(x => x.UserId).ToList();
            var branchesToSearch = request.Keys.Select(x => x.BranchId).ToList();
            var servicesToSearch = request.Keys.Select(x => x.ServiceId).ToList();

            var newStatus = request.AppointmentStatus.ToString();

            var entities = (await _context.Appointments
                    .Where(x => usersToSearch.Contains(x.UserId) &&
                                branchesToSearch.Contains(x.BranchId) &&
                                servicesToSearch.Contains(x.ServiceId) &&
                                x.Status != newStatus)
                    .ToListAsync(cancellationToken))
                .Where(x => request.Keys
                    .Any(key => key.UserId == x.UserId &&
                                key.BranchId == x.BranchId &&
                                key.ServiceId == x.ServiceId)).ToList();
            if (!entities.Any()) return;

            foreach (var entity in entities)
            {
                request.Map(entity);
            }

            _context.Appointments.UpdateRange(entities);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AppointmentStatus>> GetAppointmentStatuses(CancellationToken cancellationToken = default)
        {
            return await Task.Run(EnumExtensions.GetList<AppointmentStatus>, cancellationToken);
        }

        public async Task<AppointmentListViewModel> GetPaginatedAppointments(GetPaginatedAppointments request, CancellationToken cancellationToken = default)
        {
            var entities = await _context.Appointments
                .Where(x => (!request.UserIds.Any() || request.UserIds.Contains(x.UserId)) &&
                            (!request.ServiceIds.Any() || request.ServiceIds.Contains(x.ServiceId)) &&
                            (!request.BranchIds.Any() || request.BranchIds.Contains(x.BranchId)))
                .Select(AppointmentViewModel.QueryableProjection)
                .OrderBy(x => x.ArrivalDate)
                .Skip((request.Page - 1) * request.Take)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var totalNumberOfEntities = await _context.Appointments
                .CountAsync(x => (!request.UserIds.Any() || request.UserIds.Contains(x.UserId)) &&
                                 (!request.ServiceIds.Any() || request.ServiceIds.Contains(x.ServiceId)) &&
                                 (!request.BranchIds.Any() || request.BranchIds.Contains(x.BranchId)),
                    cancellationToken: cancellationToken);

            return new AppointmentListViewModel
            {
                Appointments = entities,
                TotalNumberOfElements = totalNumberOfEntities
            };
        }
    }
}
