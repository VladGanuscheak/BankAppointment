using System.Collections.Generic;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.BranchManagement;
using BankAppointmentScheduler.Administrative.BranchManagement.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchManagement _branchManagement;

        public BranchesController(IBranchManagement branchManagement)
        {
            _branchManagement = branchManagement;
        }

        [HttpGet(nameof(GetBranchesSelectList))]
        public async Task<ActionResult<List<SelectListItem>>> GetBranchesSelectList(int? bankId)
        {
            return Ok(await _branchManagement.GetBranchesSelectList(bankId));
        }

        [HttpPost(nameof(CreateBranch))]
        public async Task<ActionResult> CreateBranch([FromBody] CreateBranchViewModel request)
        {
            await _branchManagement.CreateBranch(request);
            return Ok();
        }

        [HttpPut(nameof(UpdateBranch))]
        public async Task<ActionResult> UpdateBranch([FromBody] UpdateBranchViewModel request)
        {
            await _branchManagement.UpdateBranch(request);
            return Ok();
        }

        [HttpPut(nameof(ConfigureBranchSchedule))]
        public async Task<ActionResult> ConfigureBranchSchedule([FromBody] ConfigureBankScheduleViewModel request)
        {
            await _branchManagement.ConfigureBranchSchedule(request);
            return Ok();
        }

        [HttpPut(nameof(AssignCounterToBranch))]
        public async Task<ActionResult> AssignCounterToBranch([FromBody] AssignCounterToBranchViewModel request)
        {
            await _branchManagement.AssignCounterToBranch(request);
            return Ok();
        }
    }
}
