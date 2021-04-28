using System.Collections.Generic;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.CounterService;
using BankAppointmentScheduler.Administrative.CounterService.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountersController : ControllerBase
    {
        private readonly ICounterManagement _counterManagement;

        public CountersController(ICounterManagement counterManagement)
        {
            _counterManagement = counterManagement;
        }

        [HttpGet(nameof(GetCountersSelectList))]
        public async Task<ActionResult<List<SelectListItem>>> GetCountersSelectList(int? branchId)
        {
            return Ok(await _counterManagement.GetCountersSelectList(branchId));
        }

        [HttpPost(nameof(CreateCounter))]
        public async Task<ActionResult> CreateCounter(CreateCounterViewModel request)
        {
            await _counterManagement.CreateCounter(request);
            return Ok();
        }

        [HttpPut(nameof(UpdateCounter))]
        public async Task<ActionResult> UpdateCounter(UpdateCounterViewModel request)
        {
            await _counterManagement.UpdateCounter(request);
            return Ok();
        }

        [HttpPut(nameof(AssignOperatorToCounter))]
        public async Task<ActionResult> AssignOperatorToCounter(AssignOperatorToCounterViewModel request)
        {
            await _counterManagement.AssignOperatorToCounter(request);
            return Ok();
        }

        [HttpPut(nameof(AssignServiceToCounter))]
        public async Task<ActionResult> AssignServiceToCounter(AssignServiceToCounterViewModel request)
        {
            await _counterManagement.AssignServiceToCounter(request);
            return Ok();
        }
    }
}
