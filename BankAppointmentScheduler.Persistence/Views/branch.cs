using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class branch
    {
        public int? branch_id { get; set; }
        public int? bank_id { get; set; }
        [StringLength(128)]
        public string bank_name { get; set; }
        public long? total_counters { get; set; }
        [StringLength(128)]
        public string phone { get; set; }
        [StringLength(256)]
        public string address { get; set; }
    }
}
