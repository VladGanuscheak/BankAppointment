using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public static Expression<Func<Service, ServiceViewModel>> AsQueryableProjection
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
