using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.BankSchedulerService.RequestModels
{
    public class CreateAppointmentCommand
    {
        public Guid UserId { get; set; }

        public int BranchId { get; set; }

        public int ServiceId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public DateTime? UpdateTimestamp { get; set; }

        public string Status { get; set; }


        private static Expression<Func<CreateAppointmentCommand, Appointment>> CastProjection
        {
            get
            {
                return command => new Appointment
                {
                    UserId = command.UserId,
                    BranchId = command.BranchId,
                    ServiceId = command.ServiceId,
                    ArrivalDate = command.ArrivalDate,
                    ArrivalTime = command.ArrivalTime,
                    UpdateTimestamp = command.UpdateTimestamp,
                    Status = command.Status
                };
            }
        }

        public Appointment Cast()
        {
            return CastProjection.Compile().Invoke(this);
        }
    }
}
