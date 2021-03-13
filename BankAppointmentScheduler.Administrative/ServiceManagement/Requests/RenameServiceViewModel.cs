using System.ComponentModel.DataAnnotations;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.Administrative.ServiceManagement.Requests
{
    public class RenameServiceViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public Service Map([Required] Service entity)
        {
            if (entity.ServiceId != this.ServiceId)
                throw new NotFoundException(nameof(Service), this.ServiceId);

            entity.ServiceName = this.ServiceName;

            return entity;
        }
    }
}
