using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BankManagement.Requests
{
    public class RenameBankViewModel
    {
        public int BankId { get; set; }

        public string BankName { get; set; }


        public Bank Map(Bank entity)
        {
            if (entity.Id != this.BankId)
                throw new NotFoundException(nameof(Bank), this.BankId);

            entity.Name = this.BankName;

            return entity;
        }
    }
}
