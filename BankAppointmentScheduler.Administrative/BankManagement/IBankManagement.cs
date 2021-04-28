using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BankManagement.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Administrative.BankManagement
{
    public interface IBankManagement
    {
        Task<List<SelectListItem>> GetBanksSelectList(CancellationToken cancellationToken = default);

        Task CreateBank(CreateBankViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBank(UpdateBankViewModel request, CancellationToken cancellationToken = default);

        Task RenameBank(RenameBankViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBankUrl(UpdateBankUrlViewModel request, CancellationToken cancellationToken = default);
    }
}