using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAppointmentScheduler.Common.Extensions
{
    public class EnumExtensions
    {
        public static List<TEnum> GetList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).OfType<TEnum>().ToList();
        }
    }
}
