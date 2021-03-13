using System.Threading.Tasks;
using BankAppointmentScheduler.BankSchedulerService;
using BankAppointmentScheduler.BankSchedulerService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IBankAppointmentSchedulerService _appointmentSchedulerService;

        public AppointmentsController(IBankAppointmentSchedulerService appointmentSchedulerService)
        {
            _appointmentSchedulerService = appointmentSchedulerService;
        }

        [HttpGet(nameof(GetPaginatedAppointments))]
        public async Task<ActionResult> GetPaginatedAppointments(GetPaginatedAppointments request)
        {
            return Ok(await _appointmentSchedulerService.GetPaginatedAppointments(request));
        }

        [HttpGet(nameof(GetAppointmentStatuses))]
        public async Task<ActionResult> GetAppointmentStatuses()
        {
            return Ok(await _appointmentSchedulerService.GetAppointmentStatuses());
        }

        [HttpPost(nameof(ScheduleAppointment))]
        public async Task<ActionResult> ScheduleAppointment(CreateScheduleModel request)
        {
            await _appointmentSchedulerService.ScheduleAppointment(request);
            return Ok();
        }

        [HttpPut(nameof(UpdateAppointment))]
        public async Task<ActionResult> UpdateAppointment(UpdateScheduleModel request)
        {
            await _appointmentSchedulerService.UpdateAppointment(request);
            return Ok();
        }

        [HttpPut(nameof(ChangeAppointmentStatus))]
        public async Task<ActionResult> ChangeAppointmentStatus(UpdateAppointmentStatus request)
        {
            await _appointmentSchedulerService.ChangeAppointmentStatus(request);
            return Ok();
        }

        [HttpPut(nameof(BulkChangeAppointmentStatus))]
        public async Task<ActionResult> BulkChangeAppointmentStatus(BulkUpdateAppointmentStatus request)
        {
            await _appointmentSchedulerService.BulkChangeAppointmentStatus(request);
            return Ok();
        }
    }
}
