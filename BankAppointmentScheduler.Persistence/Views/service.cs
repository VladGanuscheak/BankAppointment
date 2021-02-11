using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class service
    {
        public int? service_id { get; set; }
        [StringLength(128)]
        public string service_name { get; set; }
        public long? total_specialized_branches { get; set; }
    }
}
