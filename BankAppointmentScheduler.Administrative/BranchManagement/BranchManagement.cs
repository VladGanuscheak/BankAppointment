using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BranchManagement.Requests;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.Administrative.BranchManagement
{
    public class BranchManagement : IBranchManagement
    {
        private readonly IBankAppointmentContext _context;

        public BranchManagement(IBankAppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetBranchesSelectList(int? bankId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Branches
                .Where(x => bankId == null || x.BankId == bankId)
                .Select(x => new SelectListItem
                {
                    Text = x.Bank.Name + " (" + x.Address + ")",
                    Value = x.BranchId.ToString()
                }).ToListAsync(cancellationToken);

            return result;
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
            var entity = await _context.Schedules.FindAsync(request.BranchId, request.WeekDay.ToString());

            Schedule mappedEntity;
            if (entity == null)
            {
                mappedEntity = request.Cast();
                await _context.Schedules.AddAsync(mappedEntity, cancellationToken);
            }
            else
            {
                mappedEntity = request.Map(entity);
                _context.Schedules.Update(mappedEntity);
            }

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
