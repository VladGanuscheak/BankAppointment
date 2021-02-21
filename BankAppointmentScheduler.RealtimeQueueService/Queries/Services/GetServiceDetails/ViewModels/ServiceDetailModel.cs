using System;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails.ViewModels
{
    public class ServiceDetailModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        public static Expression<Func<Service, ServiceDetailModel>> AsQueryableProjection
        {
            get
            {
                return service => new ServiceDetailModel
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName
                };
            }
        }
    }
}
