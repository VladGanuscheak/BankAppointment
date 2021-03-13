using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankAppointmentScheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public ServicesController(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        [HttpPost(nameof(CreateService))]
        public async Task<ActionResult> CreateService(CreateServiceViewModel request)
        {
            await _serviceManagement.CreateService(request);
            return Ok();
        }

        [HttpPut(nameof(UpdateService))]
        public async Task<ActionResult> UpdateService(RenameServiceViewModel request)
        {
            await _serviceManagement.UpdateService(request);
            return Ok();
        }
    }
}
