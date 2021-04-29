using System;
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
        public async Task<ActionResult> GetPaginatedAppointments([FromQuery] GetPaginatedAppointments request)
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
            try
            {
                await _appointmentSchedulerService.ScheduleAppointment(request);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.InnerException?.Message ?? exception.Message);
            }
            
        }

        [HttpPut(nameof(UpdateAppointment))]
        public async Task<ActionResult> UpdateAppointment(UpdateScheduleModel request)
        {
            try
            {
                await _appointmentSchedulerService.UpdateAppointment(request);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.InnerException?.Message ?? exception.Message);
            }
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

        [HttpGet(nameof(GetAppointmentDetails))]
        public async Task<ActionResult> GetAppointmentDetails(GetAppointmentDetailsQuery request)
        {
            return Ok(await _appointmentSchedulerService.GetAppointmentDetails(request));
        }

        [HttpGet(nameof(GetBranchAppointments))]
        public async Task<ActionResult> GetBranchAppointments(GetBranchAppointmentsQuery request)
        {
            return Ok(await _appointmentSchedulerService.GetBranchAppointments(request));
        }
    }
}
