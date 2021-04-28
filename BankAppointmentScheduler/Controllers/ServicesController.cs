using System.Collections.Generic;
using System.Threading.Tasks;
using BankAppointmentScheduler.Administrative.ServiceManagement;
using BankAppointmentScheduler.Administrative.ServiceManagement.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;

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

        [HttpGet(nameof(GetServicesSelectList))]
        public async Task<ActionResult<List<SelectListItem>>> GetServicesSelectList(int? counterId = null)
        {
            return Ok(await _serviceManagement.GetServicesSelectList(counterId));
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
