using System.Diagnostics;
using System.Threading;
using BankAppointmentScheduler.RealtimeQueueService;
using BankAppointmentScheduler.RealtimeQueueService.Queries.Bank.GetAllBanks;
using BankAppointmentScheduler.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankAppointmentScheduler.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBankRealtimeQueueService _queueService;

        public HomeController(ILogger<HomeController> logger, IBankRealtimeQueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        public IActionResult Index()
        {
            //var banks = _queueService.GetAllBanks(new GetAllBanksQuery(), CancellationToken.None);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
