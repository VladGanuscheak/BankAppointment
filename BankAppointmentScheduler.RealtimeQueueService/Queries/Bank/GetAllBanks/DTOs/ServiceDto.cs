using System;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.DTOs
{
    public class ServiceDto
    {
        public string ServiceName { get; set; }

        private static Expression<Func<BranchDto, ServiceDto>> Projection
        {
            get
            {
                return service => new ServiceDto
                {
                    ServiceName = service.ServiceName
                };
            }
        }

        public static ServiceDto Create(BranchDto branch)
        {
            return Projection.Compile().Invoke(branch);
        }
    }
}
