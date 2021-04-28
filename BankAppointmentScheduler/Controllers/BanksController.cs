using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BankManagement;
using BankAppointmentScheduler.Administrative.BankManagement.Requests;
using BankAppointmentScheduler.RealtimeQueueService;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBankBranches.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Branch.GetBranchDetails.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetCounterServices.ViewModels;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Services.GetServiceDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankRealtimeQueueService _bankQueueService;
        private readonly IBankManagement _bankManagement;

        public BanksController(IBankRealtimeQueueService bankQueueService, IBankManagement bankManagement)
        {
            _bankQueueService = bankQueueService;
            _bankManagement = bankManagement;
        }

        [HttpGet(Name = "GetAllBanks")]
        public async Task<ActionResult<BankListViewModel>> GetAllBanks()
        {
            var banks = await _bankQueueService.GetAllBanks(new GetAllBanksQuery(), CancellationToken.None);

            return Ok(banks);
        }

        [HttpGet("Branches/{bankId}")]
        public async Task<ActionResult<BranchesListViewModel>> Branches(int bankId)
        {
            var branches = await _bankQueueService.GetBankBranches(new GetBankBranchesQuery
            {
                BankId = bankId
            }, CancellationToken.None);

            return Ok(branches);
        }

        [HttpGet("Branch/{bankId}/{branchId}")]
        public async Task<ActionResult<BranchDetailsModel>> GetBranchDetails(int bankId, int branchId)
        {
            var branch = await _bankQueueService.GetBranchDetails(new GetBranchDetailsQuery
                {BankId = bankId, BranchId = branchId}, CancellationToken.None);

            return Ok(branch);
        }

        [HttpGet("Service/{serviceId}")]
        public async Task<ActionResult<BranchDetailsModel>> GetServiceDetails(int serviceId)
        {
            var service = await _bankQueueService.GetServiceDetails(new GetServiceDetailsQuery {ServiceId = serviceId},
                CancellationToken.None);

            return Ok(service);
        }

        [HttpGet("CounterServices/{counterId}")]
        public async Task<ActionResult<CounterViewModel>> GetCounterServices(int counterId)
        {
            var counter = await _bankQueueService.GetCounterServices(new GetCounterServicesQuery {CounterId = counterId},
                CancellationToken.None);

            return Ok(counter);
        }


        [HttpGet(nameof(GetBanksSelectList))]
        public async Task<ActionResult<List<SelectListItem>>> GetBanksSelectList()
        {
            return Ok(await _bankManagement.GetBanksSelectList());
        }

        [HttpPost(nameof(CreateBank))]
        public async Task<ActionResult> CreateBank(CreateBankViewModel model)
        {
            await _bankManagement.CreateBank(model);
            return Ok();
        }

        [HttpPut(nameof(RenameBank))]
        public async Task<ActionResult> RenameBank(RenameBankViewModel model)
        {
            await _bankManagement.RenameBank(model);
            return Ok();
        }

        [HttpPut(nameof(UpdateBankUrl))]
        public async Task<ActionResult> UpdateBankUrl(UpdateBankUrlViewModel model)
        {
            await _bankManagement.UpdateBankUrl(model);
            return Ok();
        }

        [HttpPut(nameof(UpdateBank))]
        public async Task<ActionResult> UpdateBank(UpdateBankViewModel model)
        {
            await _bankManagement.UpdateBank(model);
            return Ok();
        }
    }
}
