using System;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.CounterService.Requests
{
    public class UpdateCounterViewModel
    {
        public int CounterId { get; set; }

        public int? BranchId { get; set; }

        public Guid? OperatorId { get; set; }

        public int CounterNumber { get; set; }


        public Counter Map(Counter entity)
        {
            if (entity.CounterId != this.CounterId)
                throw new NotFoundException(nameof(Counter), this.CounterId);

            entity.BranchId = this.BranchId;
            entity.OperatorId = this.OperatorId;
            entity.CounterNumber = this.CounterNumber;

            return entity;
        }
    }
}
