using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService;
using BankAppointmentScheduler.BankSchedulerService.RequestModels;
using BankAppointmentScheduler.BankSchedulerService.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IBankAppointmentScheduler _appointmentScheduler;

        public AppointmentsController(IBankAppointmentScheduler appointmentScheduler)
        {
            _appointmentScheduler = appointmentScheduler;
        }

        [HttpGet("/{branchId}/{serviceId}/{userId}")]
        public async Task<ActionResult<AppointmentDetailsModel>> Branches([FromBody] GetAppointmentDetailsQuery query)
        {
            var appointment = await _appointmentScheduler.GetAppointmentDetails(query, CancellationToken.None);

            return Ok(appointment);
        }

        [HttpGet("Branch/{branchId}/{searchDate}")]
        public async Task<ActionResult<BranchAppointmentListViewModel>> GetBranchAppointments([FromBody] GetBranchAppointmentsQuery query)
        {
            var branchAppointments = await _appointmentScheduler.GetBranchAppointments(query);

            return Ok(branchAppointments);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAppointmentCommand item)
        {
            await _appointmentScheduler.CreateAppointment(item);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateAppointmentCommand item)
        {
            await _appointmentScheduler.UpdateAppointment(item);

            return Ok();
        }
    }
}
