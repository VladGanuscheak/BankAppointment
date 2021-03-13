using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BankManagement.Requests
{
    public class UpdateBankUrlViewModel
    {
        public int BankId { get; set; }

        public string BankUrl { get; set; }

        public Bank Map(Bank entity)
        {
            if (entity.Id != this.BankId)
                throw new NotFoundException(nameof(Bank), this.BankId);

            entity.Url = this.BankUrl;

            return entity;
        }
    }
}
