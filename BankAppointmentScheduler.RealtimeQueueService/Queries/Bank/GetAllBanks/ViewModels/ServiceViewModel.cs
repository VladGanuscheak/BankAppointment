using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        public static Expression<Func<Service, ServiceViewModel>> Projection
        {
            get
            {
                return service => new ServiceViewModel
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName
                };
            }
        }
    }
}
