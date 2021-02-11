using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class bank
    {
        public int? bank_id { get; set; }
        [StringLength(128)]
        public string bank_name { get; set; }
        [StringLength(526)]
        public string url { get; set; }
        public long? total_branches { get; set; }
    }
}
