using System;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.Administrative.BranchManagement.Requests
{
    public class ConfigureBankScheduleViewModel
    {
        public int BranchId { get; set; }

        public WeekDay? OldWeekDay { get; set; }

        public WeekDay NewWeekDay { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }


        public Schedule Cast()
        {
            return new Schedule
            {
                BranchId = this.BranchId,
                WeekDay = this.NewWeekDay.ToString(),
                OpeningTime = this.OpeningTime,
                ClosingTime = this.ClosingTime
            };
        }

        public Schedule Map(Schedule entity)
        {
            if (entity.BranchId != this.BranchId && (this.OldWeekDay == null || entity.WeekDay != this.OldWeekDay?.ToString()))
                throw new NotFoundException(nameof(Schedule), new {this.BranchId, this.OldWeekDay});

            entity.OpeningTime = this.OpeningTime;
            entity.ClosingTime = this.ClosingTime;

            return entity;
        }
    }
}
