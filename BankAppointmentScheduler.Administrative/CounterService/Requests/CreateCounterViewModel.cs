using System;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.CounterService.Requests
{
    public class CreateCounterViewModel
    {
        public int? BranchId { get; set; }

        public Guid? OperatorId { get; set; }

        public int CounterNumber { get; set; }


        public Counter Cast()
        {
            return new Counter
            {
                BranchId = this.BranchId,
                OperatorId = this.OperatorId,
                CounterNumber = this.CounterNumber
            };
        }
    }
}
