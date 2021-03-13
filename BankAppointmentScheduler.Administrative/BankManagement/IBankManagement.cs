using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BankManagement.Requests;

namespace BankAppointmentScheduler.Administrative.BankManagement
{
    public interface IBankManagement
    {
        Task CreateBank(CreateBankViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBank(UpdateBankViewModel request, CancellationToken cancellationToken = default);

        Task RenameBank(RenameBankViewModel request, CancellationToken cancellationToken = default);

        Task UpdateBankUrl(UpdateBankUrlViewModel request, CancellationToken cancellationToken = default);
    }
}