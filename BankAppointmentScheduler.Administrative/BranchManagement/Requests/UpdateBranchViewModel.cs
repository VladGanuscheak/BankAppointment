using System.ComponentModel.DataAnnotations;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.BranchManagement.Requests
{
    public class UpdateBranchViewModel
    {
        public int BranchId { get; set; }

        public int BankId { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public Branch Map([Required] Branch entity)
        {
            if (entity.BankId != this.BankId && entity.BranchId != this.BranchId)
                throw new NotFoundException(nameof(Branch), new {this.BankId, this.BranchId});

            entity.Phone = this.Phone;
            entity.Address = this.Address;

            return entity;
        }
    }
}
