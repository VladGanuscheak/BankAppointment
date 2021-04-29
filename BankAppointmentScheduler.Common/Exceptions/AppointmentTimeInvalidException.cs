using System;
using System.Text;

namespace BankAppointmentScheduler.Common.Exceptions
{
    public class AppointmentTimeInvalidException : Exception
    {
        private const string NoAvailableCounters = "there are no available counters for this service;";

        private const string BranchClosed = "the branch is closed;";

        private static string Handle(bool hasAvailableCounters, bool isBranchWorking)
        {
            var errorMessage = new StringBuilder();
            errorMessage.Append("The appointment is invalid: ");
            if (!hasAvailableCounters)
                errorMessage.Append(NoAvailableCounters);
            if (!isBranchWorking)
                errorMessage.Append(BranchClosed);

            return errorMessage.ToString();
        }

        public AppointmentTimeInvalidException(bool hasAvailableCounters, bool isBranchWorking)
            : base(Handle(hasAvailableCounters, isBranchWorking))
        {
        }
    }
}
