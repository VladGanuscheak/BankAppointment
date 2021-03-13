using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.BankSchedulerService.ResponseModels
{
    public class BranchAppointmentViewModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public DateTime? UpdateTimestamp { get; set; }


        public static Expression<Func<Appointment, BranchAppointmentViewModel>> AsQueryableProjection
        {
            get
            {
                return appointment => new BranchAppointmentViewModel
                {
                    UserId = appointment.UserId,
                    UserName = appointment.User.FirstName + " " + appointment.User.LastName,
                    ServiceId = appointment.ServiceId,
                    ServiceName = appointment.Service.ServiceName,
                    ArrivalDate = appointment.ArrivalDate,
                    ArrivalTime = appointment.ArrivalTime,
                    UpdateTimestamp = appointment.UpdateTimestamp
                };
            }
        }
    }
}
