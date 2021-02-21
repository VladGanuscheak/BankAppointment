using System;
using System.Linq.Expressions;

namespace BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.DTOs
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }


        private static Expression<Func<BranchDto, ServiceDto>> Projection
        {
            get
            {
                return service => new ServiceDto
                {
                    ServiceId = service.ServiceId,
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
