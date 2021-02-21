using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        private static Expression<Func<KeyValuePair<int, ServiceDto>, ServiceViewModel>> Projection
        {
            get
            {
                return service => new ServiceViewModel
                {
                    ServiceId = service.Key,
                    ServiceName = service.Value.ServiceName
                };
            }
        }

        public static ServiceViewModel Create(KeyValuePair<int, ServiceDto> service)
        {
            return Projection.Compile().Invoke(service);
        }
    }
}
