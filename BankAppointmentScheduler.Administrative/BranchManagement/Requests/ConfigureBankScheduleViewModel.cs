using System;
using BankAppointmentScheduler.Common.Exceptions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Domain.BankEntities.Enums;

namespace BankAppointmentScheduler.Administrative.BranchManagement.Requests
{
    public class ConfigureBankScheduleViewModel
    {
        public int BranchId { get; set; }

        public WeekDay? WeekDay { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }


        public Schedule Cast()
        {
            return new Schedule
            {
                BranchId = this.BranchId,
                WeekDay = this.WeekDay.ToString(),
                OpeningTime = this.OpeningTime,
                ClosingTime = this.ClosingTime
            };
        }

        public Schedule Map(Schedule entity)
        {
            if (entity.BranchId != this.BranchId || entity.WeekDay != this.WeekDay.ToString())
                throw new NotFoundException(nameof(Schedule), new {this.BranchId, this.WeekDay});

            entity.OpeningTime = this.OpeningTime;
            entity.ClosingTime = this.ClosingTime;

            return entity;
        }
    }
}
