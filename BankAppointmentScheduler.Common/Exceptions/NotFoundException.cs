using System;

namespace BankAppointmentScheduler.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"The entity \"{name}\" with the \"{key}\" has not been found.")
        {
        }
    }
}
