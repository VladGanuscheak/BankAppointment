using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BankAppointmentScheduler.Domain.BankEntities.Entities;

namespace BankAppointmentScheduler.BankSchedulerService.ResponseModels
{
    public class BranchAppointmentListViewModel
    {
        public int BranchId { get; set; }

        public string BranchAddress { get; set; }

        public string BranchPhone { get; set; }

        public int BankId { get; set; }

        public string BankName { get; set; }

        public string BankUrl { get; set; }

        public IList<BranchAppointmentViewModel> Appointments { get; set; }
            = new List<BranchAppointmentViewModel>();

        public static Expression<Func<Branch, BranchAppointmentListViewModel>> AsQueryableProjection
        {
            get
            {
                return branch => new BranchAppointmentListViewModel
                {
                    BranchId = branch.BranchId,
                    BankId = branch.BankId,
                    BankName = branch.Bank.Name,
                    BankUrl = branch.Bank.Url,
                    BranchAddress = branch.Address,
                    BranchPhone = branch.Phone
                };
            }
        }
    }
}
