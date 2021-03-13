using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.BankSchedulerService.ResponseModels
{
    public class AppointmentDetailsModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public int BranchId { get; set; }

        public string BranchAddress { get; set; }

        public string BranchPhone { get; set; }

        public int BankId { get; set; }

        public string BankName { get; set; }

        public string BankUrl { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public DateTime? UpdateTimestamp { get; set; }

        public static Expression<Func<Appointment, AppointmentDetailsModel>> AsQueryableProjection
        {
            get
            {
                return appointment => new AppointmentDetailsModel
                {
                    UserId = appointment.UserId,
                    UserName = appointment.User.FirstName + " " + appointment.User.LastName,
                    BranchId = appointment.BranchId,
                    BranchAddress = appointment.Branch.Address,
                    BranchPhone = appointment.Branch.Phone,
                    BankId = appointment.Branch.BankId,
                    BankName = appointment.Branch.Bank.Name,
                    BankUrl = appointment.Branch.Bank.Url,
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
