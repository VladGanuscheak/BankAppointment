using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAppointmentScheduler.Common.Extensions
{
    public static class EnumExtensions
    {
        public static List<TEnum> GetList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).OfType<TEnum>().ToList();
        }

        public static string Cast(this DayOfWeek value)
        {
            if (value == DayOfWeek.Saturday || value == DayOfWeek.Sunday)
                return value.ToString();

            return "Working";
        }
    }
}
