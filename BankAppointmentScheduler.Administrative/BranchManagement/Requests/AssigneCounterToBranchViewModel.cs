using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BranchManagement.Requests
{
    public class AssignCounterToBranchViewModel
    {
        public int CounterId { get; set; }

        public int BranchId { get; set; }


        public Counter Map(Counter entity)
        {
            if (entity.CounterId != this.CounterId)
                throw new NotFoundException(nameof(Counter), this.CounterId);

            entity.BranchId = this.BranchId;

            return entity;
        }
    }
}
