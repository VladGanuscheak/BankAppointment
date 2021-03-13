using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BankManagement.Requests
{
    public class CreateBankViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }


        public Bank Cast()
        {
            return new Bank()
            {
                Name = this.Name,
                Url = this.Url
            };
        }
    }
}
