using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class appointment
    {
        public Guid? user_id { get; set; }
        public int? branch_id { get; set; }
        public int? service_id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? arrival_date { get; set; }
        [Column(TypeName = "time without time zone")]
        public TimeSpan? arrival_time { get; set; }
        [StringLength(64)]
        public string status { get; set; }
        public DateTime? update_tmstmp { get; set; }
    }
}
