using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BankManagement.Requests
{
    public class UpdateBankViewModel
    {
        public int BankId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }


        public Bank Map(Bank entity)
        {
            if (entity.Id != this.BankId)
                throw new NotFoundException(nameof(Bank), this.BankId);

            entity.Name = this.Name;
            entity.Url = this.Url;

            return entity;
        }
    }
}
