using System;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.CounterService.Requests
{
    public class AssignOperatorToCounterViewModel
    {
        public int CounterId { get; set; }

        public Guid? OperatorId { get; set; }



        public Counter Map(Counter entity)
        {
            if (entity.CounterId != this.CounterId)
                throw new NotFoundException(nameof(Counter), this.CounterId);

            entity.OperatorId = this.OperatorId;

            return entity;
        }
    }
}
