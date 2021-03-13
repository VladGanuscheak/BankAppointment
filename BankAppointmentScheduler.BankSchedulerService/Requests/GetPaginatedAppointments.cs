using System;
using System.Collections.Generic;

namespace BankAppointmentScheduler.BankSchedulerService.Requests
{
    public class GetPaginatedAppointments
    {
        public int Take { get; set; }

        public int Page { get; set; }


        #region Filters

        public IList<Guid> UserIds { get; set; } = new List<Guid>();

        public IList<int> BranchIds { get; set; } = new List<int>();

        public IList<int> ServiceIds { get; set; } = new List<int>();

        #endregion
    }
}
