using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.BankSchedulerService.ViewModels
{
    public class AppointmentViewModel
    {
        #region Appointment

        public DateTime ArrivalDate { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public string Status { get; set; }

        public DateTime? UpdateTimestamp { get; set; }

        #endregion

        #region User

        public Guid UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        #endregion

        #region Service

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        #endregion

        #region Branch

        public int BranchId { get; set; }

        public string BranchPhone { get; set; }

        public string BranchAddress { get; set; }

        #endregion

        #region Bank

        public int BankId { get; set; }

        public string BankName { get; set; }

        public string BankUrl { get; set; }

        #endregion

        public static Expression<Func<Appointment, AppointmentViewModel>> QueryableProjection
        {
            get
            {
                return appointment => new AppointmentViewModel
                {
                    ArrivalDate = appointment.ArrivalDate,
                    ArrivalTime = appointment.ArrivalTime,
                    Status = appointment.Status,
                    UpdateTimestamp = appointment.UpdateTimestamp,

                    UserId = appointment.UserId,
                    UserEmail = appointment.User.Email,
                    UserFirstName = appointment.User.FirstName,
                    UserLastName = appointment.User.LastName,
                    
                    ServiceId = appointment.ServiceId,
                    ServiceName = appointment.Service.ServiceName,
                    
                    BranchId = appointment.BranchId,
                    BranchAddress = appointment.Branch.Address,
                    BranchPhone = appointment.Branch.Phone,
                    
                    BankId = appointment.Branch.BankId,
                    BankName = appointment.Branch.Bank.Name,
                    BankUrl = appointment.Branch.Bank.Url
                };
            }
        }
    }
}
