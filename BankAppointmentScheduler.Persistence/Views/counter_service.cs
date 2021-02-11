using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class counter_service
    {
        public int? counter_id { get; set; }
        [StringLength(128)]
        public string bank_name { get; set; }
        public int? branch_id { get; set; }
        public int? counter_number { get; set; }
        public int? service_id { get; set; }
        [StringLength(128)]
        public string service_name { get; set; }
    }
}
